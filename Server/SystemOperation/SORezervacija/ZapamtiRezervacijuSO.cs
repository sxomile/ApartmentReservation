using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
    internal class ZapamtiRezervacijuSO : SystemOperationBase
    {
        private Rezervacija rezervacija;
        public bool Result { get; set; } = false;
        public ZapamtiRezervacijuSO(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }

        protected override void ExecuteConcreteOperation()
        {
			List<IEntity> rezs = new List<IEntity>(broker.GetAll(rezervacija));
			Result = rezervacija.Validate(rezervacija, rezs);
            if (Result) broker.Add(rezervacija);
        }
    }
}
