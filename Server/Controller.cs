using Common.Domain;
using DBBroker;
using Server.SystemOperation.SOLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Controller
    {
        private static Controller _instance;
        public static Controller Instance {  get { if (_instance == null) _instance = new Controller(); return _instance; } }

        internal object Login(User korisnik)
        {
            LoginSO loginSO = new LoginSO(korisnik);
            loginSO.ExecuteTemplate();
            return loginSO.result;
        }
    }
}
