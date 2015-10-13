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
        public static List<ChatMessage> Chat { get; }

        public static string Name;

        public static int Session;
        public static bool Loggedin;

        private static Thread t;
        private static bool running;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;

        static MainClient()
        {
            ComPort = new ComPort();
            Doctor = new TcpClient();
            Metingen = new List<Meting>();
            Chat = new List<ChatMessage>();

            t = new Thread(run);

            Name = "Unknown";
            Session = 0;
            Loggedin = false;
        }

        public static bool Connect(string comport, string name, string password)
        {
            if (!Doctor.Connected)
            {
                Doctor.Connect(HOST, PORT);
                Name = name;

                NetCommand net = NetHelper.ReadNetCommand(Doctor);
                if (net.Type == NetCommand.CommandType.SESSION)
                    Session = net.Session;
                else
                    throw new Exception("Session not assigned");

                running = true;
                t.Start();
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
                running = false;
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

        public static void run()
        {
            while(running)
            {
                if(Doctor.Connected && Doctor.Available > 0)
                {
                    NetCommand command = NetHelper.ReadNetCommand(Doctor);
                    ParseCommand(command);
                }
            }

            Doctor.Close();
        }

        private static void ParseCommand(NetCommand command)
        {
            switch(command.Type)
            {
                case NetCommand.CommandType.VALUESET:
                    ParseValueSet(command);
                    break;
                case NetCommand.CommandType.CHAT:
                    Chat.Add(new ChatMessage(Name, command.ChatMessage));
                    break;
                case NetCommand.CommandType.RESPONSE:
                    Console.WriteLine(command.Response.ToString());
                    break;
                case NetCommand.CommandType.SESSION:
                    Session = command.Session;
                    break;
                default:
                    throw new FormatException("Error in Netcommand: Received command not recognized");
            }
        }

        private static void ParseValueSet(NetCommand command)
        {
            switch(command.Value)
            {
                case NetCommand.ValueType.DISTANCE:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("PD " + command.SetValue.ToString());
                    ComPort.Read();
                    break;
                case NetCommand.ValueType.ENERGY:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("PE " + command.SetValue.ToString());
                    ComPort.Read();
                    break;
                case NetCommand.ValueType.POWER:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("PW " + command.SetValue.ToString());
                    ComPort.Read();
                    break;
                case NetCommand.ValueType.TIME:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    string time = (command.SetValue / 60) + ":" + (command.SetValue % 60);
                    ComPort.Write("PT " + time);
                    ComPort.Read();
                    break;
                default:
                    throw new FormatException("Error in NetCommand: ValueSet is not recognized");
            }
        }
    }
}
