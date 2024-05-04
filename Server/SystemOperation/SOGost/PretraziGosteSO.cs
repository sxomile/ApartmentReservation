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
        public BindingList<User> Result { get; set; } = null;

        public PretraziGosteSO(string upit)
        {
            this.upit = upit;
        }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.PretraziGoste(upit);
        }
    }
}
