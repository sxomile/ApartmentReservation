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
            int domId = broker.AddWithId(domacinstvo);
            domacinstvo.DomacinstvoId = domId;
			foreach (Apartman apartman in domacinstvo.Apartmani)
			{
				broker.Add(apartman);
			}
            Result = true;
        }
    }
}
