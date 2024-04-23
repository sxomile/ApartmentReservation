using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Domacinstvo : IEntity
    {
        public int DomacinstvoId { get; set; }
        public string Naziv { get; set; }
        public int BrojApartmana { get; set; }
        public string TableName => "Domacinstvo";

        public string Values => $"'{DomacinstvoId}', '{Naziv}', '{BrojApartmana}'";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
