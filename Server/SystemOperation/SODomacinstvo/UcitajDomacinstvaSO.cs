using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
    internal class UcitajDomacinstvaSO : SystemOperationBase
    {
        public List<IEntity> Result { get; set; } = null;

        protected override void ExecuteConcreteOperation()
        {
            IEntity domacinstvo = new Domacinstvo();
            Result = broker.GetAll(domacinstvo);
        }
    }
}
