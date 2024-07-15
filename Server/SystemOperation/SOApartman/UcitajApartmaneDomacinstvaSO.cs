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
        public BindingList<IEntity> Result { get; set; } = null;
        public UcitajApartmaneDomacinstvaSO(Domacinstvo domacinstvo)
        {
            this.domacinstvo = domacinstvo;
        }
        protected override void ExecuteConcreteOperation()
        {
            Apartman apt = new Apartman();
            Result = broker.GetAllWithFilter(apt, "DomacinstvoId", domacinstvo.DomacinstvoId.ToString());
        }
    }
}
