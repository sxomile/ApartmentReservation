using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
	internal class UcitajRezervacijuSO : SystemOperationBase
	{
		private IEntity obj;
		public IEntity Result { get; set; }
		public UcitajRezervacijuSO(IEntity obj)
		{
			this.obj = obj;
		}
		protected override void ExecuteConcreteOperation()
		{
			Result = broker.GetEntityById(obj);
			User gost = (User)broker.GetEntityById(new User { Id = ((Rezervacija)obj).GostID });
			Apartman apartman = (Apartman)broker.GetEntityById(new Apartman { ApartmanId = ((Rezervacija)obj).ApartmanID });
			Domacinstvo dom = (Domacinstvo)broker.GetEntityById(new Domacinstvo { DomacinstvoId = ((Rezervacija)obj).DomacinstvoID });
			((Rezervacija)Result).Apartman = apartman;
			((Rezervacija)Result).Domacinstvo = dom;
			((Rezervacija)Result).Gost = gost;

		}
	}
}
