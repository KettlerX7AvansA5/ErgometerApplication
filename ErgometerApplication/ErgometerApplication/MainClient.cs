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
        public static bool Loggedin;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;

        static MainClient()
        {
            ComPort = new ComPort();
            Doctor = new TcpClient();
            Metingen = new List<Meting>();

            Session = 0;
            Loggedin = false;
        }

        public static bool Connect(string comport, string name, string password)
        {
            if (!Doctor.Connected)
            {
                Doctor.Connect(HOST, PORT);

                NetCommand net = NetHelper.ReadNetCommand(Doctor);
                if (net.Type == NetCommand.CommandType.SESSION)
                    Session = net.Session;
                else
                    throw new Exception("Session not assigned");
            }

            if(! Loggedin)
            {
                NetCommand command = new NetCommand(name, false, password, Session);
                NetHelper.SendNetCommand(Doctor, command);

                NetCommand response = NetHelper.ReadNetCommand(Doctor);
                if (response.Type == NetCommand.CommandType.RESPONSE && response.Response == NetCommand.ResponseType.LOGINWRONG)
                {
                    Loggedin = false;
                    return false;
                }

                Loggedin = true;
            }

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

            return true;
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

            if (Doctor.Connected)
            {
                NetHelper.SendNetCommand(Doctor, new NetCommand(NetCommand.CommandType.LOGOUT, Session));
                Loggedin = false;
                Doctor.Close();
            }
        }

        public static Meting SaveMeting(string meting)
        {
            Meting m = Meting.Parse(meting);
            Metingen.Add(m);
            if (Doctor.Connected)
            {
                NetHelper.SendNetCommand(Doctor, new NetCommand(m, Session));
            }

            return m;
        }
    }
}
