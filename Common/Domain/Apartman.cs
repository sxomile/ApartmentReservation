﻿using System;
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
        public string Naziv { get; set; }
        public double? ProsecnaOcena { get; set; }
        public string TableName => "Apartman";
        public string Values => "(@DomacinstvoID, @Naziv, @ProsecnaOcena)";
        public void PrepareCommand(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DomacinstvoID", Domacinstvo.DomacinstvoId);
            cmd.Parameters.AddWithValue("@Naziv", Naziv);
            cmd.Parameters.AddWithValue("@ProsecnaOcena", ProsecnaOcena);

        }

        BindingList<IEntity> IEntity.GetReaderList(SqlDataReader reader)
        {
            BindingList<IEntity> apartmani = new BindingList<IEntity>();
            while (reader.Read())
            {
                IEntity apartman = new Apartman()
                {
                    Naziv = (string)reader["Naziv"],
                    ProsecnaOcena = (double)reader["ProsecnaOcena"]
                };

                apartmani.Add(apartman);
            }

            reader.Close();

            return apartmani;
        }
    }
}
