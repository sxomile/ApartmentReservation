using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOLogin
{
    internal class LoginSO : SystemOperationBase
    {
        private User korisnik;
        public User Result {  get; set; }
        public LoginSO(User korisnik)
        {
            this.korisnik = korisnik;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.Login(korisnik);
        }
    }
}
