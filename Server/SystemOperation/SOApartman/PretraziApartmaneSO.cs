using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOApartman
{
    internal class PretraziApartmaneSO : SystemOperationBase
    {
        private string upit;
        public BindingList<IEntity> Result { get; set; } = null;
        public PretraziApartmaneSO(string upit)
        {
            this.upit = upit;
        }
        protected override void ExecuteConcreteOperation()
        {
            Apartman apt = new Apartman();
            Result = broker.GetAllWithFilter(apt, "naziv", $"'%{upit}%'");
        }
    }
}
