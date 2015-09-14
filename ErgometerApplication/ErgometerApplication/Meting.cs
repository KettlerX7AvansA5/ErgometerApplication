using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    class Meting
    {
        public int HeartBeat { get; }
        public int RPM { get; }
        public double Speed { get; }
        public double Distance { get; }
        public int Power { get; }
        public int Energy { get; }
        public int Seconds { get; }
        public int ActualPower { get; }

        public Meting(int heartbeat, int rpm, double speed, double distance, int power, int energy, int seconds, int actualpower)
        {
            HeartBeat = heartbeat;
            RPM = rpm;
            Speed = speed;
            Distance = distance;
            Power = power;
            Energy = energy;
            Seconds = seconds;
            ActualPower = actualpower;
        }

        public override string ToString()
        {
            string temp = "";
            temp += "Heartbeat: " + HeartBeat + "\n";
            temp += "RPM: " + RPM + "\n";
            temp += "Speed: " + Speed + "\n";
            temp += "Distance: " + Distance + "\n";
            temp += "Power: " + Power + "\n";
            temp += "Energy: " + Energy + "\n";
            temp += "Seconds: " + Seconds + "\n";
            temp += "ActualPower: " + ActualPower + "\n";
            return temp;
        }
    }
}
