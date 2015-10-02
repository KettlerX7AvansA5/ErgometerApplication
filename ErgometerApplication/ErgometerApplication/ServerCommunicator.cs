using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ErgometerLibrary;

namespace ErgometerApplication
{
    class ServerCommunicator
    {
        public TcpClient client { get; set; }
        public int sessionId { get; set; }
        public List<Meting> data { get; set; } 
    }
}
