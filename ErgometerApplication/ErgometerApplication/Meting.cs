using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    public class Meting
    {
        public int HeartBeat { get; set; }
        public int RPM { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public int Power { get; set; }
        public int Energy { get; set; }
        public int Seconds { get; set; }
        public int ActualPower { get; set; }

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
        public Meting()
        {

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
