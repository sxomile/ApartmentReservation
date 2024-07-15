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
        //OVO CELO NE SME DA POSTOJI, NADJI MU MESTO I TAMO ZAMENI SA KLASOM KOJOJ PRIPADA
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetEntityById(obj);
        }
    }
}
