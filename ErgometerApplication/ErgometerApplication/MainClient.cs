using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    class MainClient
    {

        public static ComPort ComPort { get; }
        public static TcpClient Doctor { get; }
        public static List<Meting> Metingen { get; }

        public static int Session;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;

        static MainClient()
        {
            ComPort = new ComPort();
            Doctor = new TcpClient();
            Metingen = new List<Meting>();

            Session = 0;
        }

        public static void Connect(string comport, string name, string password)
        {
            if (!ComPort.IsOpen())
            {
                if (ComPort.Connect(comport))
                {
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("CM");
                    ComPort.Read();
                    Thread.Sleep(200);

                    ComPort.Write("ST");
                    string response = ComPort.Read();
                    Console.WriteLine(response);

                    SaveMeting(response);
                }
                else
                    throw new Exception("Comport was unable to connect");
            }
            else
                throw new Exception("Comport is already connected");


            if(!Doctor.Connected)
            {
                Doctor.Connect(HOST, PORT);

                NetCommand net = NetHelper.ReadNetCommand(Doctor);
                if (net.Type == NetCommand.CommandType.SESSION)
                    Session = net.Session;
                else
                    throw new Exception("Session not assigned");

                NetCommand command = new NetCommand(name, false, password, Session);
                NetHelper.SendNetCommand(Doctor, command);
            }
            else
                throw new Exception("Client is already connected");
        }

        public static void Disconnect()
        {
            if (ComPort.IsOpen())
            {
                if (ComPort.Disconnect())
                {
                    
                }
                else
                    throw new Exception("Comport was unable to disconnect");
            }
            else
                throw new Exception("Comport is already closed");

            if (Doctor.Connected)
            {
                NetHelper.SendNetCommand(Doctor, new NetCommand(NetCommand.CommandType.LOGOUT, Session));
                Doctor.Close();
            }
            else
                throw new Exception("Client is already disconnected");
        }

        public static void SaveMeting(string meting)
        {
            Meting m = Meting.Parse(meting);
            Metingen.Add(m);
            if (Doctor.Connected)
            {
                NetHelper.SendNetCommand(Doctor, new NetCommand(m, Session));
            }
        }
    }
}
