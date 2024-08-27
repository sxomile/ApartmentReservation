using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
    internal class NadjiDomacinstvaSO : SystemOperationBase
    {
        private string upit;
        public List<IEntity> Result { get; set; } = null;
        public NadjiDomacinstvaSO(string upit)
        {
            this.upit = upit;
        }
        protected override void ExecuteConcreteOperation()
        {
			IEntity domacinstvo = new Domacinstvo();
			Result = broker.GetAllWithFilter(domacinstvo, "naziv", $"'%{upit}%'");
        }
    }
}
