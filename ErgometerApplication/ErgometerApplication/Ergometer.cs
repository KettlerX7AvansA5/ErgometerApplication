using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ErgometerApplication
{
    public partial class Ergometer : Form
    {
        private ComPort comPort;
        private Meting schrijfweg;
        private List<Meting> _data;
        public Ergometer()
        {
            InitializeComponent();
            comPort = new ComPort();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!comPort.IsOpen())
            {
                if (comPort.Connect(ComPortBox.Text))
                {
                    connectButton.Text = "Disconnect";
                    statusButton.Enabled = true;
                    resetButton.Enabled = true;
                    timerStatus.Enabled = true;
                    inputTextBox.Enabled = true;
                    timeButton.Enabled = true;
                    distanceButton.Enabled = true;
                    powerButton.Enabled = true;
                    energyButton.Enabled = true;
                    ComPortBox.Enabled = false;

                    comPort.Write("RS");
                    comPort.Read();
                    Thread.Sleep(200);
                    comPort.Write("CM");
                    comPort.Read();
                    Thread.Sleep(200);

                    comPort.Write("ST");
                    string response = comPort.Read();
                    Console.WriteLine(response);

                    Meting test = FormatHelper.Status(response);
                    schrijfweg = test;
                    string test2 = test.ToString();
                    richTextBox1.Text = test2;
                }
            }
            else
            {
                if (comPort.Disconnect())
                {
                    connectButton.Text = "Connect";
                    timerStatus.Checked = false;
                    statusButton.Enabled = false;
                    resetButton.Enabled = false;
                    timerStatus.Enabled = false;
                    inputTextBox.Enabled = false;
                    timeButton.Enabled = false;
                    distanceButton.Enabled = false;
                    powerButton.Enabled = false;
                    energyButton.Enabled = false;
                    ComPortBox.Enabled = true;
                    richTextBox1.Text = "";

                }
            }


        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            comPort.Write("ST");
            string response = comPort.Read();
            Console.WriteLine(response);
            richTextBox1.Text = FormatHelper.Status(response).ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            comPort.Write("RS");
            comPort.Read();
            Thread.Sleep(200);
            comPort.Write("CM");
            comPort.Read();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (timerStatus.Checked)
            {
                comPort.Write("ST");
                string response = comPort.Read();
                Console.WriteLine(response);
                richTextBox1.Text = FormatHelper.Status(response).ToString();
            }
        }

        private void timeButton_Click(object sender, EventArgs e)
        {
            comPort.Write("RS");
            comPort.Read();
            Thread.Sleep(200);
            string[] temp = inputTextBox.Text.Split(':');
            comPort.Write("PT " + temp[0] + temp[1]);
            Console.WriteLine("PT " + temp[0] + temp[1]);
            inputTextBox.Text = "";
            comPort.Read();
        }

        private void distanceButton_Click(object sender, EventArgs e)
        {
            comPort.Write("RS");
            comPort.Read();
            Thread.Sleep(200);
            int temp = int.Parse(inputTextBox.Text);
            comPort.Write("PD " + temp.ToString());
            inputTextBox.Text = "";
            comPort.Read();
        }

        private void powerButton_Click(object sender, EventArgs e)
        {
            int temp = int.Parse(inputTextBox.Text);
            comPort.Write("PW " + temp.ToString());
            inputTextBox.Text = "";
            comPort.Read();
        }

        private void energyButton_Click(object sender, EventArgs e)
        {
            comPort.Write("RS");
            comPort.Read();
            Thread.Sleep(200);
            int temp = int.Parse(inputTextBox.Text);
            comPort.Write("PE " + temp.ToString());
            inputTextBox.Text = "";
            comPort.Read();
        }

        private void timerStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (timerStatus.Checked)
            {
                statusButton.Enabled = false;
                updateTimer.Start();
                saveTimer.Start();
                writeTimer.Start();
            }
            else
            {
                statusButton.Enabled = true;
                updateTimer.Stop();
                saveTimer.Stop();
                writeTimer.Stop();
            }
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            saveData(schrijfweg);
        }

        private void writeFile()
        {

            string json = JsonConvert.SerializeObject(_data.ToArray());

            System.IO.File.WriteAllText(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//path.ergo", json);
        }
        private void saveData(Meting meting)
        {
            _data = new List<Meting>();
            _data.Add(new Meting()
            {
                HeartBeat = schrijfweg.HeartBeat,
                RPM = schrijfweg.RPM,
                Speed = schrijfweg.Speed,
                Distance = schrijfweg.Distance,
                Power = schrijfweg.Power,
                Energy = schrijfweg.Energy,
                Seconds = schrijfweg.Seconds,
                ActualPower = schrijfweg.ActualPower
            });
        }

        private void writeTimer_Tick(object sender, EventArgs e)
        {
            writeFile();
        }

        private void Ergometer_Load(object sender, EventArgs e)
        {

        }
    }
}