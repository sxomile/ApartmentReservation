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

        public string GetIdQuery()
        {
            return $"RezervacijaID = '{RezervacijaID}'";
        }

        public BindingList<IEntity> GetReaderList(SqlDataReader reader)
        {
            BindingList<IEntity> rezervacije = new BindingList<IEntity>();
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
    }
}
