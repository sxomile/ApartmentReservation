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
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Role Uloga { get; set; }

        public string TableName => "[User]";

        public string Values => throw new NotImplementedException();

        public string GetIdQuery()
        {
            return $"Id = {Id}";
        }

        public BindingList<IEntity> GetReaderList(SqlDataReader reader)
        {
            BindingList<IEntity> users = new BindingList<IEntity>();
            while (reader.Read())
            {
                IEntity user = new User()
                {
                    Id = (int)reader["ID"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    Username = (string)reader["Username"],
                    Uloga = (Role)reader["Uloga"]
                };

                users.Add(user);
            }

            reader.Close();

            return users;
        }

        public void PrepareCommand(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public void SetValues(IEntity entity, SqlDataReader reader)
        {
            if (reader.Read())
            {
                ((User)entity).Id = (int)reader["ID"];
                ((User)entity).Username = reader["Username"].ToString();
                ((User)entity).Ime = reader["Ime"].ToString();
                ((User)entity).Prezime = reader["Prezime"].ToString();
            }

            reader.Close();
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime} {Username}";
        }
    }
}
