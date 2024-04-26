using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
    internal class DodajDomacinstvoSO : SystemOperationBase
    {
        private Domacinstvo domacinstvo;
        public bool Result { get; set; } = false;
        public DodajDomacinstvoSO(Domacinstvo domacinstvo)
        {
            this.domacinstvo = domacinstvo;
        }

        protected override void ExecuteConcreteOperation()
        {
            //broker.Add(domacinstvo);
            int domId = broker.GetDomacinstvoId(domacinstvo);
            domacinstvo.DomacinstvoId = domId;
            Result = broker.DodajApartmane(domacinstvo);
        }
    }
}
