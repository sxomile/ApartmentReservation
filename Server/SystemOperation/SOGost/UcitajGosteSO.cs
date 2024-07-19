using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOGost
{
    internal class UcitajGosteSO : SystemOperationBase
    {
        public List<IEntity> Result { get; set; } = null;

        protected override void ExecuteConcreteOperation()
        {
            IEntity gost = new User();
            Result = broker.GetAll(gost);
        }
    }
}
