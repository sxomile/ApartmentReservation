using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOGost
{
    internal class UcitajGosteSO : SystemOperationBase
    {
        public List<IEntity> Result { get; set; } = null;

        protected override void ExecuteConcreteOperation()
        {
            IEntity user = new User();
            List<IEntity> users = broker.GetAll(user);
            if(users.Count > 0)
            {
                Result = new List<IEntity>();
				foreach (IEntity korisnik in users)
				{
					if (((User)korisnik).Uloga == Role.Gost)
					{
						Result.Add(korisnik);
					}
				}
			}
        }
    }
}
