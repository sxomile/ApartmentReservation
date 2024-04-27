using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public List<Apartman> Apartmani { get; set; } = null;
        public string TableName => "Domacinstvo";

        public string Values => "(@Naziv, @BrojApartmana)";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void PrepareCommand(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Naziv", Naziv);
            cmd.Parameters.AddWithValue("@BrojApartmana", BrojApartmana);
        }

        BindingList<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            BindingList<IEntity> domacinstva = new BindingList<IEntity>();
            while(reader.Read())
            {
                IEntity domacinstvo = new Domacinstvo()
                {
                    Naziv = (string)reader["Naziv"],
                    BrojApartmana = (int)reader["BrojApartmana"]
                };

                domacinstva.Add(domacinstvo);
            }

            reader.Close();

            return domacinstva;
        }
    }
}
