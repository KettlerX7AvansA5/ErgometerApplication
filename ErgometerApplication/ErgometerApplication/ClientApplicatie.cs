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
using System.Net.Sockets;
using System.Net;
using System.Timers;
using ErgometerLibrary;

namespace ErgometerApplication
{
    public partial class ClientApplicatie : Form
    {
        private ComPort comPort;
        private TcpClient doctor;
        //private List<Meting> _data;
        //private int i = 0;
        //NetCommand command;
        //private ServerCommunicator communicator = new ServerCommunicator();
        //List<Meting> readFile = new List<Meting>();

        public ClientApplicatie()
        {
              InitializeComponent();
              comPort = new ComPort();

              doctor = new TcpClient("127.0.0.1", 8888);

        //    _data = new List<Meting>();
        //    communicator.data = _data;
        }

        //private void connectButton_Click(object sender, EventArgs e)
        //{
        //    if (!comPort.IsOpen())
        //    {
        //        if (comPort.Connect(ComPortBox.Text))
        //        {
        //            connectButton.Text = "Disconnect";
        //            statusButton.Enabled = true;
        //            resetButton.Enabled = true;
        //            timerStatus.Enabled = true;
        //            inputTextBox.Enabled = true;
        //            timeButton.Enabled = true;
        //            distanceButton.Enabled = true;
        //            powerButton.Enabled = true;
        //            energyButton.Enabled = true;
        //            ComPortBox.Enabled = false;

        //            comPort.Write("RS");
        //            comPort.Read();
        //            Thread.Sleep(200);
        //            comPort.Write("CM");
        //            comPort.Read();
        //            Thread.Sleep(200);

        //            comPort.Write("ST");
        //            string response = comPort.Read();
        //            Console.WriteLine(response);

        //            Meting m = Meting.Parse(response);
        //            SaveData(m);
        //           // richTextBox1.Text = m.ToString();
        //        }
        //    }
        //    else
        //    {
        //        if (comPort.Disconnect())
        //        {
        //            connectButton.Text = "Connect";
        //            timerStatus.Checked = false;
        //            statusButton.Enabled = false;
        //            resetButton.Enabled = false;
        //            timerStatus.Enabled = false;
        //            inputTextBox.Enabled = false;
        //            timeButton.Enabled = false;
        //            distanceButton.Enabled = false;
        //            powerButton.Enabled = false;
        //            energyButton.Enabled = false;
        //            ComPortBox.Enabled = true;
        //            richTextBox1.Text = "";

        //            WriteFile();

        //        }
        //    }
        //    communicator.client = new TcpClient();
        //    communicator.client.Connect("127.0.0.1", 8888);
        //    Thread thread = new Thread(ServerCommunication);
        //    thread.Start(communicator);
        //}

        //private void statusButton_Click(object sender, EventArgs e)
        //{
        //    comPort.Write("ST");
        //    string response = comPort.Read();
        //    Console.WriteLine(response);
        //    Meting m = Meting.Parse(response, '\t');
        //    Console.WriteLine(m);
        //    SaveData(m);
        //    communicator.data.Add(m);
        //    command = new NetCommand(m, communicator.sessionId);
        //    NetHelper.SendNetCommand(communicator.client, command);
        //    richTextBox1.Text = m.ToString();
        //    WriteFile();
        //}

        //static void ServerCommunication(object obj)
        //{
        //    ServerCommunicator communicator = obj as ServerCommunicator;

        //    NetCommand net = NetHelper.ReadNetCommand(communicator.client);
        //    if (net.Type == NetCommand.CommandType.SESSION)
        //        communicator.sessionId = net.Session;

        //    NetCommand command = new NetCommand("name", false, "pass", communicator.sessionId);
        //    NetHelper.SendNetCommand(communicator.client, command);
        //}

        //private void resetButton_Click(object sender, EventArgs e)
        //{
        //    comPort.Write("RS");
        //    comPort.Read();
        //    Thread.Sleep(200);
        //    comPort.Write("CM");
        //    comPort.Read();
        //}

        //private void updateTimer_Tick(object sender, EventArgs e)
        //{
        //    if (timerStatus.Checked)
        //    {
        //        comPort.Write("ST");
        //        string response = comPort.Read();
        //        Console.WriteLine(response);
        //        Meting m = Meting.Parse(response);
        //        SaveData(m);
        //        communicator.data.Add(m);
        //        command = new NetCommand(m, communicator.sessionId);
        //        NetHelper.SendNetCommand(communicator.client, command);
        //        richTextBox1.Text = m.ToString();
        //        command = new NetCommand(communicator.data[0], communicator.sessionId);
        //        NetHelper.SendNetCommand(communicator.client, command);
        //    }
        //}

        //private void timeButton_Click(object sender, EventArgs e)
        //{
        //    comPort.Write("RS");
        //    comPort.Read();
        //    Thread.Sleep(200);
        //    string[] temp = inputTextBox.Text.Split(':');
        //    comPort.Write("PT " + temp[0] + temp[1]);
        //    Console.WriteLine("PT " + temp[0] + temp[1]);
        //    inputTextBox.Text = "";
        //    comPort.Read();
        //}

        //private void distanceButton_Click(object sender, EventArgs e)
        //{
        //    comPort.Write("RS");
        //    comPort.Read();
        //    Thread.Sleep(200);
        //    int temp = int.Parse(inputTextBox.Text);
        //    comPort.Write("PD " + temp.ToString());
        //    inputTextBox.Text = "";
        //    comPort.Read();
        //}

        //private void powerButton_Click(object sender, EventArgs e)
        //{
        //    int temp = int.Parse(inputTextBox.Text);
        //    comPort.Write("PW " + temp.ToString());
        //    inputTextBox.Text = "";
        //    comPort.Read();
        //}

        //private void energyButton_Click(object sender, EventArgs e)
        //{
        //    comPort.Write("RS");
        //    comPort.Read();
        //    Thread.Sleep(200);
        //    int temp = int.Parse(inputTextBox.Text);
        //    comPort.Write("PE " + temp.ToString());
        //    inputTextBox.Text = "";
        //    comPort.Read();
        //}

        //private void timerStatus_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (timerStatus.Checked)
        //    {
        //        statusButton.Enabled = false;
        //        updateTimer.Start();
        //        writeTimer.Start();
        //    }
        //    else
        //    {
        //        statusButton.Enabled = true;
        //        updateTimer.Stop();
        //        writeTimer.Stop();
        //    }
        //}

        //private void readButton_Click(object sender, EventArgs e)
        //{
        //    ReadFile();
        //    if (readFile != null)
        //    {
        //        metingNextButton.Enabled = true;
        //        metingBackButton.Enabled = true;
        //    }

        //}

        //private void metingBackButton_Click(object sender, EventArgs e)
        //{
        //    if (i > 0)
        //    { i--;
        //      metingNextButton.Enabled = true;
        //    }
        //    if (i == 0)
        //    {
        //        metingBackButton.Enabled = false;
        //    }
        //    richTextBox1.Text = readFile.ElementAt(i).ToString();
        //}

        //private void metingNextButton_Click(object sender, EventArgs e)
        //{
        //    if (i < (readFile.Count - 1))
        //    { i++;
        //      metingBackButton.Enabled = true;
        //    }
        //    if (i == (readFile.Count - 1))
        //    {
        //        metingNextButton.Enabled = false;
        //    }
        //    richTextBox1.Text = readFile.ElementAt(i).ToString();
        //}

        //private void writeTimer_Tick(object sender, EventArgs e)
        //{
        //    WriteFile();
        //}


        //private void WriteFile()
        //{
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
        //    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ErgometerSessionData.ergo");
        //    System.IO.File.WriteAllText(path, json);
        //    Console.WriteLine("Writing file: " + path);
        //}

        //private void SaveData(Meting meting)
        //{
        //    _data.Add(meting);
        //}

        //private void ReadFile()
        //{
        //    string path;
        //    OpenFileDialog file = new OpenFileDialog();
        //    file.Filter = "Ergometer files(*.ergo) | *.ergo | All files(*.*) | *.*";
        //    if (file.ShowDialog() == DialogResult.OK)
        //    {
        //        path = file.FileName;
        //        readFile = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Meting>>(System.IO.File.ReadAllText(path));
        //        richTextBox1.Text = readFile.ElementAt(i).ToString();
        //    }
        //    else
        //    {
        //        readFile = null;
        //    }
        //}

        public void validateLogin(string username, string password)
        {
            if(username.Length >= 4)
            {
                if(password.Length == 0)
                {
                    panelLogin.lblVerification.Text = "Vul een wachtwoord in.";
                    panelLogin.lblVerification.ForeColor = Color.Red;
                    panelLogin.lblVerification.Visible = true;
                }
                if (password.Length > 0 && password.Length < 9)
                {
                    panelLogin.lblVerification.Text = "Vul een wachtwoord in van minimaal 8 karakters.";
                    panelLogin.lblVerification.ForeColor = Color.Red;
                    panelLogin.lblVerification.Visible = true;
                }
                if (password.Length >= 8)
                {
                    //password checken
                    panelClientContainer.BringToFront();
                    this.labelUsername.Text = panelLogin.textBoxUsername.Text;
                    panelTopBar.Visible = true;
                }
            }
            else
            {
                panelLogin.lblVerification.Text = "Vul een gebruikersnaam in van minimaal 4 karakters.";
                panelLogin.lblVerification.ForeColor = Color.Red;
                panelLogin.lblVerification.Visible = true;
            }
        }

        private void ClientApplicatie_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            if(control.Size.Width < 980)
            {
                panelGraphView.Visible = false;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Fill;
            }
            if (control.Size.Width >= 980 && control.Size.Width < 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 250;
                panelClientChat.Width = 300;
                panelDataViewLeft.Dock = DockStyle.Left;
            }
            if (control.Size.Width >= 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }

        }

        public void sessionLogout()
        {

        }

        private void buttonLogOff_Click(object sender, EventArgs e)
        {
            panelLogin.BringToFront();
            panelTopBar.Visible = false;
            sessionLogout();
        }

        
    }
}