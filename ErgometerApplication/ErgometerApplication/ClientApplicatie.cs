﻿using System;
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
        public ClientApplicatie()
        {
            InitializeComponent();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if(MainClient.Doctor.Connected)
            {
                MainClient.ComPort.Write("ST");
                string response = MainClient.ComPort.Read();
                MainClient.SaveMeting(response);
            }
        }

        public void validateLogin(string username, string password)
        {
            if (username.Length >= 4)
            {
                if (password.Length == 0)
                {
                    panelLogin.lblVerification.Text = "Vul een wachtwoord in.";
                    panelLogin.lblVerification.ForeColor = Color.Red;
                    panelLogin.lblVerification.Visible = true;
                }
                if (password.Length > 0 && password.Length < 8)
                {
                    panelLogin.lblVerification.Text = "Vul een wachtwoord in van minimaal 8 karakters.";
                    panelLogin.lblVerification.ForeColor = Color.Red;
                    panelLogin.lblVerification.Visible = true;
                }
                if (password.Length >= 8)
                {
                    MainClient.Connect(SerialPort.GetPortNames()[0], username, password);
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
            if (control.Size.Width < 980)
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
            MainClient.Disconnect();
        }

        private void buttonLogOff_Click(object sender, EventArgs e)
        {
            panelLogin.BringToFront();
            panelTopBar.Visible = false;
            sessionLogout();
        }
    }
}