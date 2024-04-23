using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Sender
    {
        private Socket socket;
        private BinaryFormatter formatter;
        private NetworkStream stream;

        public Sender(Socket socket)
        {
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(socket);
        }

        public void Send(object argument)
        {
            formatter.Serialize(stream, argument);
        }
    }
}
