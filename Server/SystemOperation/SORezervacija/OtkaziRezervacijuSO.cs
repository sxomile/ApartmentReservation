using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
    internal class OtkaziRezervacijuSO : SystemOperationBase
    {
        private Rezervacija rezervacija;
        public bool Result { get; set; } = false;
        public OtkaziRezervacijuSO(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }
        protected override void ExecuteConcreteOperation()
        {
            broker.Delete(rezervacija);
            Result = true;
        }
    }
}
