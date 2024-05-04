using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SORezervacija
{
    internal class UcitajRezervacijeSO : SystemOperationBase
    {
        public BindingList<IEntity> Result { get; set; } = null;
        protected override void ExecuteConcreteOperation()
        {
            IEntity rezervacija = new Rezervacija();
            Result = broker.GetAll(rezervacija);
            foreach (IEntity entity in Result)
            {
                Apartman apartman = new Apartman() { ApartmanId = ((Rezervacija)entity).ApartmanID};
                Domacinstvo domacinstvo = new Domacinstvo() { DomacinstvoId = ((Rezervacija)entity).DomacinstvoID};
                User gost = new User() { Id = ((Rezervacija)entity).GostID };
                ((Rezervacija)entity).Apartman = (Apartman)broker.GetEntityById(apartman);
                ((Rezervacija)entity).Domacinstvo = (Domacinstvo)broker.GetEntityById(domacinstvo);
                ((Rezervacija)entity).Gost = (User)broker.GetEntityById(gost);
            }
        }
    }
}
