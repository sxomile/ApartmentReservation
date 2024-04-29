using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOApartman
{
    internal class UcitajApartmaneSO : SystemOperationBase
    {
        public BindingList<IEntity> Result { get; set; } = null;
        protected override void ExecuteConcreteOperation()
        {
            IEntity apartman = new Apartman();
            Result = broker.GetAll(apartman);
        }
    }
}
