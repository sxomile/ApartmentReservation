using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOEntity
{
    internal class GetEntityByIdSO : SystemOperationBase
    {
        private IEntity obj;
        public IEntity Result {  get; set; }
        public GetEntityByIdSO(IEntity obj)
        {
            this.obj = obj;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetEntityById(obj);
        }
    }
}
