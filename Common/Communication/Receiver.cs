using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Receiver
    {
        private Socket socket;
        private BinaryFormatter _formatter;
        private NetworkStream _stream;

        public Receiver(Socket socket)
        {
            this.socket = socket;
            _formatter = new BinaryFormatter();
            _stream = new NetworkStream(socket);
        }

        public object Receive()
        {
            return _formatter.Deserialize(_stream);
        }

    }
}
