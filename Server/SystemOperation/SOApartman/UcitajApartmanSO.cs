using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOApartman
{
	internal class UcitajApartmanSO : SystemOperationBase
	{
		private IEntity obj;
		public IEntity Result { get; set; }
		public UcitajApartmanSO(IEntity obj)
		{
			this.obj = obj;
		}
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetEntityById(obj);
			Domacinstvo dom = new Domacinstvo { DomacinstvoId = ((Apartman)obj).DomacinstvoId };
			((Apartman)obj).Domacinstvo = (Domacinstvo)broker.GetEntityById(dom);
		}
	}
}
