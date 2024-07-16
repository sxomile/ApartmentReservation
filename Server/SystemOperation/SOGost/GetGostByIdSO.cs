using Common.Domain;
using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOGost
{
	internal class GetGostByIdSO : SystemOperationBase
	{
		private IEntity obj;
		public IEntity Result { get; set; }
		public GetGostByIdSO(IEntity obj)
		{
			this.obj = obj;
		}
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetEntityById(obj);

		}
	}
}
