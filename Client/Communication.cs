using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {
        private static Communication _instance;
        public static Communication Instance { get { if(_instance == null ) _instance = new Communication(); return _instance; } }

        Socket socket;
        Sender sender;
        Receiver receiver;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            receiver = new Receiver(socket);
            sender = new Sender(socket);
        }

        public void Close()
        {
            socket?.Close();
        }

        public User Login(string username, string password)
        {
            User korisnik = new User()
            {
                Username = username,
                Password = password
            };

            Request req = new Request()
            {
                Operation = Operation.Login,
                Argument = korisnik,
            };
            sender.Send(req);

            return (User)((Response)receiver.Receive()).Result;
        }
    }
}
