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
    public class Apartman : IEntity
    {
        public int ApartmanId { get; set; }
        public Domacinstvo Domacinstvo { get; set; }
        public int DomacinstvoId {  get; set; }
        public string Naziv { get; set; }
        public double? ProsecnaOcena { get; set; }
        public string TableName => "Apartman";
        public string Values => "(@DomacinstvoID, @Naziv, @ProsecnaOcena)";

        public string GetIdQuery(string use = "")
        {
            return $"ApartmanId = {ApartmanId}";
        }

        public void PrepareCommand(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DomacinstvoID", Domacinstvo.DomacinstvoId);
            cmd.Parameters.AddWithValue("@Naziv", Naziv);
            cmd.Parameters.AddWithValue("@ProsecnaOcena", ProsecnaOcena);

        }

        public void SetValues(IEntity entity, SqlDataReader reader)
        {
            if (reader.Read())
            {
                ((Apartman)entity).ApartmanId = (int)reader["ApartmanID"];
                ((Apartman)entity).DomacinstvoId = (int)reader["DomacinstvoID"];
                ((Apartman)entity).Naziv = reader["Naziv"].ToString();
                ((Apartman)entity).ProsecnaOcena = (double)reader["ProsecnaOcena"];
            }
            reader.Close();
        }

        List<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            List<IEntity> apartmani = new List<IEntity>();
            while (reader.Read())
            {
                IEntity apartman = new Apartman()
                {
                    Naziv = (string)reader["Naziv"],
                    ProsecnaOcena = (double)reader["ProsecnaOcena"],
                    DomacinstvoId = (int)reader["DomacinstvoID"],
                    ApartmanId = (int)reader["ApartmanID"]
                };

                apartmani.Add(apartman);
            }

            reader.Close();

            return apartmani;
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
