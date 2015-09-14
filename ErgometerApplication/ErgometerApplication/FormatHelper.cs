using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    class FormatHelper
    {
        public static Meting Status(string input)
        {
            String[] status = input.Split('\t');

            if (status.Length != 8)
                return null;

            int heartbeat = int.Parse(status[0]);
            int rpm = int.Parse(status[1]);
            double speed = double.Parse(status[2]) / 10;
            double distance = double.Parse(status[3]) / 10;
            int power = int.Parse(status[4]);
            int energy = int.Parse(status[5]);
            int actualpower = int.Parse(status[7]);

            string[] temp = status[6].Split(':');
            int seconds = (int.Parse(temp[0]) * 60) + (int.Parse(temp[1]));

            return new Meting(heartbeat, rpm, speed, distance, power, energy, seconds, actualpower);
        }
    }
}