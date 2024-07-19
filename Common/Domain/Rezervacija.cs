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
    public class Rezervacija : IEntity
    {
        public string RezervacijaID {  get; set; }
        public int ApartmanID {  get; set; }
        public Apartman Apartman { get; set; }
        public int DomacinstvoID {  get; set; }
        public Domacinstvo Domacinstvo { get; set; }
        public int GostID {  get; set; }
        public User Gost { get; set; }
        public DateTime DatumOd {  get; set; }
        public DateTime DatumDo { get; set; }

        public string TableName => "Rezervacija";

        public string Values => "(@RezervacijaID, @ApartmanID, @GostID, @DatumOd, @DatumDo, @DomacinstvoID)";

        public string GetIdQuery(string use = "")
        {
            return $"RezervacijaID = '{RezervacijaID}'";
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> rezervacije = new List<IEntity>();
            while (reader.Read())
            {
                IEntity rezervacija = new Rezervacija()
                {
                    RezervacijaID = (string)reader["RezervacijaID"],
                    ApartmanID = (int)reader["ApartmanID"],
                    DomacinstvoID = (int)reader["DomacinstvoId"],
                    GostID = (int)reader["GostID"],
                    DatumOd = (DateTime)reader["DatumOd"],
                    DatumDo = (DateTime)reader["DatumDo"]
                };

                rezervacije.Add(rezervacija);
            }
            
            reader.Close();

            return rezervacije;
        }

        public void PrepareCommand(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@RezervacijaID", RezervacijaID);
            cmd.Parameters.AddWithValue("@ApartmanID", ApartmanID);
            cmd.Parameters.AddWithValue("@GostID", GostID);
            cmd.Parameters.AddWithValue("@DatumOd", DatumOd);
            cmd.Parameters.AddWithValue("@DatumDo", DatumDo);
            cmd.Parameters.AddWithValue("@DomacinstvoID", DomacinstvoID);
        }

        public void SetValues(IEntity entity, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

		public bool Validate(IEntity entity, List<IEntity> entities)
		{
            Rezervacija data = (Rezervacija)entity;
			List<Rezervacija> rezervacije = new List<Rezervacija>();

			foreach (IEntity ent in entities)
			{
				Rezervacija rez = (Rezervacija)ent;
				rezervacije.Add(rez);
			}

			foreach (Rezervacija rezervacija in rezervacije)
			{
				if (rezervacija.DatumOd < data.DatumDo && data.DatumOd < rezervacija.DatumDo && rezervacija.ApartmanID == data.ApartmanID)
					return false;
			}

			return true;
		}
	}
}
