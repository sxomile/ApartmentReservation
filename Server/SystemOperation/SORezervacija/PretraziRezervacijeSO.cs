using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
    internal class PretraziRezervacijeSO : SystemOperationBase
    {
        private string upit;
        public BindingList<Rezervacija> Result { get; set; } = null;
        public PretraziRezervacijeSO(string upit)
        {
            this.upit = upit;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.PretraziRezervacije(upit);
        }
    }
}
