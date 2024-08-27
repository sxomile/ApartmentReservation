using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOGost
{
    internal class PretraziGosteSO : SystemOperationBase
    {
        private string upit;
        public List<IEntity> Result { get; set; } = null;

        public PretraziGosteSO(string upit)
        {
            this.upit = upit;
        }

        protected override void ExecuteConcreteOperation()
        {
            User user = new User();
            Result = broker.GetAllWithFilter(user, "(ime", $"'%{upit}%' or prezime like '%{upit}%' or username like '%{upit}%' or ime + ' ' + prezime like '%{upit}%') and uloga = {(int)Role.Gost}");
        }
    }
}
