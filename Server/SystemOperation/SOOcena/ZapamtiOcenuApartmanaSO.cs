using Common.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperation.SOOcena
{
    internal class ZapamtiOcenuApartmanaSO : SystemOperationBase
    {
        private Ocena ocena;
        public bool Result { get; set; } = false;
        public ZapamtiOcenuApartmanaSO(Ocena ocena)
        {
            this.ocena = ocena;
        }
        protected override void ExecuteConcreteOperation()
        {
            try
            {
                broker.Add(ocena);
                Result = true;
            } catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Result = false;
            }
        }
    }
}
