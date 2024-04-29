using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class Broker
    {
        private DBConnection connection;

        public Broker()
        {
            connection = new DBConnection();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Add(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {obj.TableName} values {obj.Values}";
            obj.PrepareCommand(cmd);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public BindingList<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from {entity.TableName}";
            SqlDataReader reader = command.ExecuteReader();
            BindingList<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public void Commit()
        {
            connection.Commit();       
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public User Login(User user)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from [user] where username = '{user.Username}' and password = '{user.Password}'";
            SqlDataReader reader = command.ExecuteReader();
            try
            {

                if (reader.Read())
                {
                    user.Prezime = (string)reader["prezime"];
                    user.Ime = (string)reader["ime"];
                    user.Id = (int)reader["id"];
                    user.Uloga = (Role)reader["uloga"];
                    return user;
                }
            }
            finally
            {
                reader.Close();
            }
            return null;
        }

        public bool DodajApartmane(Domacinstvo domacinstvo)
        {
            foreach (Apartman apartman in domacinstvo.Apartmani)
            {
                Add(apartman);
            }

            return true;

        }

        public int GetDomacinstvoId(Domacinstvo domacinstvo)
        {
            int id = 0;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {domacinstvo.TableName} values {domacinstvo.Values} select scope_identity() as [scope]";
            domacinstvo.PrepareCommand(cmd);
            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                id = Convert.ToInt32(result); 
            }
            cmd.Dispose();
            return id;
        }

        public BindingList<Domacinstvo> PretraziDomacinstvo(string upit)
        {
            BindingList<Domacinstvo> domacinstva = new BindingList<Domacinstvo>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select * from domacinstvo where naziv like '%{upit}%'";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Domacinstvo domacinstvo = new Domacinstvo()
                {
                    Naziv = (string)reader["Naziv"],
                    BrojApartmana = (int)reader["BrojApartmana"]
                };

                domacinstva.Add(domacinstvo);
            }

            reader.Close();

            return domacinstva;
        }

        public BindingList<Apartman> PretraziApartmane(string upit)
        {
            BindingList<Apartman> apartmani = new BindingList<Apartman>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select * from apartman where naziv like '%{upit}%'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Apartman apartman = new Apartman()
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
