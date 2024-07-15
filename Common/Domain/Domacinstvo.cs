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

        public string GetIdQuery(string use = "")
        {
            return $"DomacinstvoId = {DomacinstvoId}";
        }

        public void PrepareCommand(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Naziv", Naziv);
            cmd.Parameters.AddWithValue("@BrojApartmana", BrojApartmana);
        }

        public void SetValues(IEntity dom, SqlDataReader reader)
        {
            if (reader.Read())
            {
                ((Domacinstvo)dom).DomacinstvoId = (int)reader["DomacinstvoID"];
                ((Domacinstvo)dom).Naziv = (string)reader["Naziv"];
                ((Domacinstvo)dom).BrojApartmana = (int)reader["BrojApartmana"];
            }
            reader.Close();
        }

        BindingList<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            BindingList<IEntity> domacinstva = new BindingList<IEntity>();
            while(reader.Read())
            {
                IEntity domacinstvo = new Domacinstvo()
                {
                    DomacinstvoId = (int)reader["DomacinstvoID"],
                    Naziv = (string)reader["Naziv"],
                    BrojApartmana = (int)reader["BrojApartmana"]
                };

                domacinstva.Add(domacinstvo);
            }

            reader.Close();

            return domacinstva;
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }

		public bool Validate(IEntity entity, List<IEntity> entities)
		{
			throw new NotImplementedException();
		}
	}
}
