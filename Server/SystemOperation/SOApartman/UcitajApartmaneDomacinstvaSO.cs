using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOApartman
{
    internal class UcitajApartmaneDomacinstvaSO : SystemOperationBase
    {
        private Domacinstvo domacinstvo;
        public List<Apartman> Result { get; set; } = null;
        public UcitajApartmaneDomacinstvaSO(Domacinstvo domacinstvo)
        {
            this.domacinstvo = domacinstvo;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.UcitajApartmaneDomacinstva(domacinstvo);
        }
    }
}
