using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        internal bool DodajDomacinstvo(string nazivDomacinstva, DataGridView dgvApartmani)
        {
            List<Apartman> apartmani = new List<Apartman>();    
            foreach(DataGridViewRow row in dgvApartmani.Rows)
            {
                if (!row.IsNewRow)
                {
                    Apartman apartman = new Apartman()
                    {
                        Naziv = row.Cells[0].Value.ToString(),
                        ProsecnaOcena = 0,
                    };

                    apartmani.Add(apartman);
                }
            }

            Domacinstvo domacinstvo = new Domacinstvo()
            {
                Naziv = nazivDomacinstva,
                Apartmani = apartmani,
                BrojApartmana = apartmani.Count(),
            };

            foreach(Apartman apt in domacinstvo.Apartmani)
            {
                apt.Domacinstvo = domacinstvo;
            }

            Request req = new Request()
            {
                Operation = Operation.DodajDomacinstvo,
                Argument = domacinstvo,
            };

            sender.Send(req);

            return (bool)((Response)receiver.Receive()).Result;

        }

        internal BindingList<IEntity> GetAllDomacinstvo()
        {
            Request req = new Request()
            {
                Operation = Operation.GetAllDomacinstvo,
            };

            sender.Send(req);   
            return (BindingList<IEntity>)((Response)receiver.Receive()).Result;
        }

        internal BindingList<Domacinstvo> PretraziDomacinstva(string upit)
        {
            Request req = new Request()
            {
                Operation = Operation.PretraziDomacinstva,
                Argument = upit,
            };

            sender.Send(req);
            return (BindingList<Domacinstvo>)((Response)receiver.Receive()).Result;
        }

        internal BindingList<IEntity> GetAllApartman()
        {
            Request req = new Request()
            {
                Operation = Operation.GetAllApartman
            };
            sender.Send(req);
            return (BindingList<IEntity>)((Response)receiver.Receive()).Result;   
        }

        internal BindingList<Apartman> PretraziApartmane(string upit)
        {
            Request req = new Request()
            {
                Operation = Operation.PretraziApartmane,
                Argument = upit,
            };

            sender.Send(req);
            return (BindingList<Apartman>)((Response)receiver.Receive()).Result;
        }
    }
}
