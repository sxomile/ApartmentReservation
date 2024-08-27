using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SODomacinstvo
{
	internal class UcitajDomacinstvoSO : SystemOperationBase
	{
		private IEntity obj;
		public IEntity Result { get; set; }
		public UcitajDomacinstvoSO(IEntity obj)
		{
			this.obj = obj;
		}
		
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetEntityById(obj);
			Apartman apt = new Apartman();
			List<IEntity> apartmani = broker.GetAllWithFilter(apt, "DomacinstvoId", ((Domacinstvo)obj).DomacinstvoId.ToString());
			List<Apartman> apts = new List<Apartman>();
			foreach (IEntity ent in apartmani)
			{
				apts.Add((Apartman)ent);
			}
			((Domacinstvo)Result).Apartmani = apts;
		}
	}
}
