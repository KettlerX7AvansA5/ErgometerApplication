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
using System.IO;
using ErgometerLibrary;
using System.Net.Sockets;
using System.Net;

namespace ErgometerApplication
{
    public partial class Ergometer : Form
    {
        private ComPort comPort;
        private List<Meting> _data;
        private int i = 0;
        int sessionID;
        NetCommand command;
        List<Meting> readFile = new List<Meting>();
        System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
        public Ergometer()
        {
            InitializeComponent();
            comPort = new ComPort();
            _data = new List<Meting>();
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

                    Meting m = Meting.Parse(response);
                    SaveData(m);
                   // richTextBox1.Text = m.ToString();
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

                    WriteFile();

                }
            }
            IPAddress ipAddress; //= IPAddress.Parse("127.0.0.1");

            bool ipIsOk = IPAddress.TryParse("127.0.0.1", out ipAddress); //GetIp()
            if (!ipIsOk) { Console.WriteLine("ip adres kan niet geparsed worden."); Environment.Exit(1); }
            client.Connect("127.0.0.1", 8888);
            WriteServer("5»ses?");
            sessionID = int.Parse(ReadServer());
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            comPort.Write("ST");
            string response = comPort.Read();
            Console.WriteLine(response);
            Meting m = Meting.Parse(response);
            SaveData(m);
            command = new NetCommand(m, sessionID);
            WriteServer(command.ToString());
            richTextBox1.Text = m.ToString();
            WriteFile();
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
                Meting m = Meting.Parse(response);
                SaveData(m);
                command = new NetCommand(m, sessionID);
                WriteServer(command.ToString());
                richTextBox1.Text = m.ToString();
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
                writeTimer.Start();
            }
            else
            {
                statusButton.Enabled = true;
                updateTimer.Stop();
                writeTimer.Stop();
            }
        }

        

        private void readButton_Click(object sender, EventArgs e)
        {
            ReadFile();
            if (readFile != null)
            {
                metingNextButton.Enabled = true;
                metingBackButton.Enabled = true;
            }

        }

        private void metingBackButton_Click(object sender, EventArgs e)
        {
            if (i > 0)
            { i--;
              metingNextButton.Enabled = true;
            }
            if (i == 0)
            {
                metingBackButton.Enabled = false;
            }
            richTextBox1.Text = readFile.ElementAt(i).ToString();
        }

        private void metingNextButton_Click(object sender, EventArgs e)
        {
            if (i < (readFile.Count - 1))
            { i++;
              metingBackButton.Enabled = true;
            }
            if (i == (readFile.Count - 1))
            {
                metingNextButton.Enabled = false;
            }
            richTextBox1.Text = readFile.ElementAt(i).ToString();
        }

        private void writeTimer_Tick(object sender, EventArgs e)
        {
            WriteFile();
        }


        private void WriteFile()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ErgometerSessionData.ergo");
            System.IO.File.WriteAllText(path, json);
            Console.WriteLine("Writing file: " + path);
        }

        private void SaveData(Meting meting)
        {
            _data.Add(meting);
        }

        private void ReadFile()
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Ergometer files(*.ergo) | *.ergo | All files(*.*) | *.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                readFile = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Meting>>(System.IO.File.ReadAllText(path));
                richTextBox1.Text = readFile.ElementAt(i).ToString();
            }
            else
            {
                readFile = null;
            }
        }
        
        private String ReadServer()
        {

            StreamReader reader = new StreamReader(client.GetStream(), Encoding.ASCII);
            String b = reader.ReadLine();
            return b;
        }
        private void WriteServer(String Send)
        {

            StreamWriter stream = new StreamWriter(client.GetStream(), Encoding.ASCII);
            stream.WriteLine(Send);

        }
    }
}