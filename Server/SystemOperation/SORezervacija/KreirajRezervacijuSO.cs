using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
    internal class KreirajRezervacijuSO : SystemOperationBase
    {
        private Rezervacija rezervacija;
        public bool Result { get; set; } = false;
        public KreirajRezervacijuSO(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.ProveriRezervaciju(rezervacija);
            if (Result) broker.Add(rezervacija);
        }
    }
}
