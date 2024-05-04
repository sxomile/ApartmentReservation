using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Socket socket;
        private Sender sender;
        private Receiver receiver;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        public void HandleRequest()
        {
            while(true)
            {
                Request req = (Request)receiver.Receive();
                Response res = ProcessRequest(req);
                sender.Send(res);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response res = new Response();
            try
            {
                switch (req.Operation)
                {
                    case Operation.Login:
                        
                        res.Result = Controller.Instance.Login((User)req.Argument);

                    break;

                    case Operation.DodajDomacinstvo:

                        res.Result = Controller.Instance.DodajDomacinstvo((Domacinstvo)req.Argument);

                    break;

                    case Operation.GetAllDomacinstvo:

                        res.Result = Controller.Instance.GetAllDomacinstvo();

                    break;

                    case Operation.PretraziDomacinstva:

                        res.Result = Controller.Instance.PretraziDomacinstva((string)req.Argument);

                    break;

                    case Operation.GetAllApartman:

                        res.Result = Controller.Instance.GetAllApartman();

                    break;

                    case Operation.PretraziApartmane:

                        res.Result = Controller.Instance.PretraziApartmane((string)req.Argument);

                    break;

                    case Operation.GetEntityById:

                        res.Result = Controller.Instance.GetEntityById((IEntity)req.Argument);

                    break;

                    case Operation.KreirajRezervaciju:

                        res.Result = Controller.Instance.KreirajRezervaciju((Rezervacija)req.Argument);

                    break;

                    case Operation.GetAllGosti:

                        res.Result = Controller.Instance.GetAllGosti();

                    break;

                    case Operation.PretraziGoste:

                        res.Result = Controller.Instance.PretraziGoste((string) req.Argument);

                    break;

                    case Operation.GetAllRezervacije:

                        res.Result = Controller.Instance.GetAllRezervacije();

                    break;

                    case Operation.PretraziRezervacije:

                        res.Result = Controller.Instance.PretraziRezervacije((string)req.Argument);

                    break;

                }
            } catch (Exception e)
            {
                Debug.WriteLine(">>> " + e.Message);
                res.Exception = e;
            }

            return res;
        }
    }
}
