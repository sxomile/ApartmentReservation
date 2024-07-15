using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            if (socket == null || !socket.Connected)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ConfigurationManager.AppSettings["ip"], int.Parse(ConfigurationManager.AppSettings["port"]));
                receiver = new Receiver(socket);
                sender = new Sender(socket);
            }
            
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
                if (!row.IsNewRow && row.Cells[0].Value != null && row.Cells[0].Value.ToString() != string.Empty)
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
            return new BindingList<Domacinstvo>((List<Domacinstvo>)((Response)receiver.Receive()).Result);
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
            return new BindingList<Apartman>((List<Apartman>)((Response)receiver.Receive()).Result);
        }

        internal IEntity GetEntityById(object obj)
        {
            Request request = new Request()
            {
                Operation = Operation.GetEntityById,
                Argument = obj
            };
            sender.Send(request);
            return (IEntity)((Response)receiver.Receive()).Result;
        }

        internal bool KreirajRezervaciju(Rezervacija rezervacija)
        {
            Request req = new Request()
            {
                Operation = Operation.KreirajRezervaciju,
                Argument = rezervacija,
            };
            sender.Send(req);
            return (bool)((Response)receiver.Receive()).Result;
        }

        internal BindingList<IEntity> GetAllGosti()
        {
            Request req = new Request()
            {
                Operation = Operation.GetAllGosti,
            };
            sender.Send(req);   
            return (BindingList<IEntity>)((Response)receiver.Receive()).Result;
        }

        internal BindingList<User> PretraziGoste(string upit)
        {
            Request req = new Request()
            {
                Operation = Operation.PretraziGoste,
                Argument = upit
            };

            sender.Send(req);
            return new BindingList<User>((List<User>)((Response)receiver.Receive()).Result);
        }

        internal BindingList<IEntity> UcitajRezervacije()
        {
            Request req = new Request()
            {
                Operation = Operation.GetAllRezervacije,
            };

            sender.Send(req);
            return (BindingList<IEntity>)((Response)receiver.Receive()).Result;
        }

        internal BindingList<Rezervacija> PretraziRezervacije(string upit)
        {
            Request req = new Request()
            {
                Operation = Operation.PretraziRezervacije,
                Argument = upit
            };

            sender.Send(req);
            return new BindingList<Rezervacija>((List<Rezervacija>)((Response)receiver.Receive()).Result);
        }

        internal bool OceniApartman(Ocena ocena)
        {
            Request req = new Request()
            {
                Operation = Operation.Oceni,
                Argument = ocena,
            };

            sender.Send(req);
            return (bool)((Response)receiver.Receive()).Result;
            
        }

        internal bool OtkaziRezervaciju(Rezervacija reservation)
        {
            Request request = new Request()
            {
                Operation = Operation.OtkaziRezervaciju,
                Argument = reservation
            };

            sender.Send(request);
            return (bool)((Response)receiver.Receive()).Result;
        }

        internal List<Apartman> GetApartmentsOfDomacinstvo(Domacinstvo domacinstvo)
        {
            Request request = new Request()
            {
                Operation = Operation.GetApartmentsOfDomacinstvo,
                Argument = domacinstvo
            };

            sender.Send(request);
            return (List<Apartman>)((Response)receiver.Receive()).Result;
        }

        internal bool IzmeniDomacinstvo(Domacinstvo novoDomacinstvo, Domacinstvo staroDomacinstvo)
        {
            Tuple<Domacinstvo, Domacinstvo> domacinstva = new Tuple<Domacinstvo, Domacinstvo>(novoDomacinstvo, staroDomacinstvo);
            Request req = new Request()
            {
                Argument = domacinstva, //PRVO NOVO, DRUGO STARO
                Operation = Operation.IzmeniDomacinstvo,
            };

            sender.Send(req);
            return (bool)((Response)receiver.Receive()).Result;
        }
    }
}
