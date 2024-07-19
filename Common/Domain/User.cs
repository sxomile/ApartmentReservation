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
        public string TableName => "User";

        public string Values => throw new NotImplementedException();

        public string GetIdQuery(string use = "")
        {
            switch (use)
            {
                case "login":

                    return $"username = '{Username}' and password = '{Password}'";

                default:
					return $"Id = {Id}";
			}
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> users = new List<IEntity>();
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
                ((User)entity).Uloga = (Role)reader["Uloga"];
            }

            reader.Close();
        }

        public override string ToString()
        {
            return $"{Ime} {Prezime} {Username}";
        }

		public bool Validate(IEntity entity)
		{
			throw new NotImplementedException();
		}

		public bool Validate(IEntity entity, List<IEntity> entities)
		{
			throw new NotImplementedException();
		}
	}
}
