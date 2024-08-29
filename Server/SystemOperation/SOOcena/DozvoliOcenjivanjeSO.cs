using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOOcena
{
	internal class DozvoliOcenjivanjeSO : SystemOperationBase
	{
		private Ocena ocena;
		public bool Result = false;
		public DozvoliOcenjivanjeSO(Ocena ocena)
		{
			this.ocena = ocena;
		}
		protected override void ExecuteConcreteOperation()
		{
			Rezervacija testRez = new Rezervacija()
			{
				ApartmanID = ocena.ApartmanId,
				GostID = ocena.GostId,
			};
			List<IEntity> rezervacije = broker.GetAllWithFilter(testRez, "ApartmanId", $"{ocena.ApartmanId} and GostId = {ocena.GostId}");
			if(rezervacije.Count > 0 )
			{
				Result = true;
			}
			else
			{
				Result = false;
			}
		}
	}
}
