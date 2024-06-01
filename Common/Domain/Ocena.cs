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
    public class Ocena : IEntity
    {
        public int DomacinstvoId {  get; set; }
        public Domacinstvo Domacinstvo { get; set; }
        public int ApartmanId {  get; set; }
        public Apartman Apartman {  get; set; }
        public int GostId {  get; set; }
        public User Gost {  get; set; }
        public int OcenaApartmana {  get; set; }

        public string TableName => "OcenaApartmana";

        public string Values => "(@DomacinstvoID, @ApartmanID, @GostID, @OcenaApartmana)";

        public string GetIdQuery()
        {
            return $"ApartmanId = {ApartmanId}";
        }

        public BindingList<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void PrepareCommand(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DomacinstvoID", DomacinstvoId);
            cmd.Parameters.AddWithValue("@ApartmanID", ApartmanId);
            cmd.Parameters.AddWithValue("@GostID", GostId);
            cmd.Parameters.AddWithValue("@OcenaApartmana", OcenaApartmana);
        }

        public void SetValues(IEntity entity, SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
