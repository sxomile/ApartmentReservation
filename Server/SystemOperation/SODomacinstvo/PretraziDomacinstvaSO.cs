using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
    internal class PretraziDomacinstvaSO : SystemOperationBase
    {
        private string upit;
        public BindingList<Domacinstvo> Result { get; set; } = null;
        public PretraziDomacinstvaSO(string upit)
        {
            this.upit = upit;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.PretraziDomacinstvo(upit);
        }
    }
}
