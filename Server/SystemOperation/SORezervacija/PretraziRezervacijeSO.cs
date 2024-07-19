using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
    internal class PretraziRezervacijeSO : SystemOperationBase
    {
        private string upit;
        public List<IEntity> Result { get; set; } = null;
        public PretraziRezervacijeSO(string upit)
        {
            this.upit = upit;
        }
        protected override void ExecuteConcreteOperation()
        {
            Rezervacija rezervacija = new Rezervacija();
            Result = broker.GetAllWithFilter(rezervacija, "RezervacijaID", $"'%{upit}%'");

			foreach (Rezervacija rez in Result)
			{
				Apartman apt = new Apartman() { ApartmanId = rez.ApartmanID };
				Domacinstvo dom = new Domacinstvo() { DomacinstvoId = rez.DomacinstvoID };
				User gost = new User { Id = rez.GostID };
				rez.Apartman = (Apartman)broker.GetEntityById(apt);
				rez.Domacinstvo = (Domacinstvo)broker.GetEntityById(dom);
				rez.Gost = (User)broker.GetEntityById(gost);
			}
		}
    }
}
