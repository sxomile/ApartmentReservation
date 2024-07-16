using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
	internal class GetDomacinstvoByIdSO : SystemOperationBase
	{
		private IEntity obj;
		public IEntity Result { get; set; }
		public GetDomacinstvoByIdSO(IEntity obj)
		{
			this.obj = obj;
		}
		
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetEntityById(obj);
		}
	}
}
