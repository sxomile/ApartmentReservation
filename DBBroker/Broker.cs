﻿using Common.Domain;
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

        public void Delete(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from {entity.TableName} where {entity.GetIdQuery()}";
            command.ExecuteNonQuery();
            command.Dispose();
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
                    BrojApartmana = (int)reader["BrojApartmana"],
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
                    ProsecnaOcena = (double)reader["ProsecnaOcena"],
                    DomacinstvoId = (int)reader["DomacinstvoID"],
                    ApartmanId = (int)reader["ApartmanID"]
                };

                apartmani.Add(apartman);
            }

            reader.Close();

            return apartmani;
        }

        public IEntity GetEntityById(IEntity obj)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select top 1 * from {obj.TableName} where {obj.GetIdQuery()}";
            SqlDataReader reader = command.ExecuteReader();
            obj.SetValues(obj, reader);
            return obj;
        }

        public bool ProveriRezervaciju(Rezervacija data)
        {
            List<IEntity> rezs = new List<IEntity>(GetAll(data));
            List<Rezervacija> rezervacije = new List<Rezervacija>();

            foreach(IEntity ent in rezs)
            {
                Rezervacija rez = (Rezervacija)ent;
                rezervacije.Add(rez);
            }

            foreach(Rezervacija rezervacija in rezervacije)
            {
                if (rezervacija.DatumOd < data.DatumDo && data.DatumOd < rezervacija.DatumDo && rezervacija.ApartmanID == data.ApartmanID)
                    return false;
            }

            return true;
        }

        public BindingList<User> PretraziGoste(string upit)
        {
            BindingList<User> gosti = new BindingList<User>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select * from [User] where ime like '%{upit}%' " +
                $"or prezime like '%{upit}%' or username = '%{upit}%' or ime + ' ' + prezime like '%{upit}%'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User gost = new User()
                {
                    Id = (int)reader["ID"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    Username = (string)reader["username"],
                    Uloga = (Role)reader["uloga"],
                };

                if(gost.Uloga == Role.Gost) gosti.Add(gost);
                
            }

            reader.Close();

            return gosti;
        }

        public BindingList<Rezervacija> PretraziRezervacije(string upit)
        {
            BindingList<Rezervacija> rezervacije = new BindingList<Rezervacija>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select * from Rezervacija where RezervacijaID like '%{upit}%'";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Rezervacija rezervacija = new Rezervacija()
                {
                    RezervacijaID = reader["RezervacijaId"].ToString(),
                    ApartmanID = (int)reader["ApartmanId"],
                    DomacinstvoID = (int)reader["DomacinstvoId"],
                    DatumOd = (DateTime)reader["DatumOd"],
                    DatumDo = (DateTime)reader["DatumDo"],
                    GostID = (int)reader["GostId"]
                };
                rezervacije.Add(rezervacija);
            }

            reader.Close();

            foreach(Rezervacija rez in rezervacije)
            {
                Apartman apt = new Apartman() {ApartmanId = rez.ApartmanID };
                Domacinstvo dom = new Domacinstvo() {DomacinstvoId = rez.DomacinstvoID};
                User gost = new User {Id = rez.GostID};
                rez.Apartman = (Apartman)GetEntityById(apt);
                rez.Domacinstvo = (Domacinstvo)GetEntityById(dom);
                rez.Gost = (User)GetEntityById(gost);
            }

            return rezervacije;
        }

        public List<Apartman> UcitajApartmaneDomacinstva(Domacinstvo domacinstvo)
        {
            List<Apartman> apartmani = new List<Apartman>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select * from [Apartman] where DomacinstvoId = {domacinstvo.DomacinstvoId}";
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Apartman apartman = new Apartman()
                {
                    DomacinstvoId = domacinstvo.DomacinstvoId,
                    ApartmanId = (int)reader["ApartmanId"],
                    Domacinstvo = domacinstvo,
                    Naziv = reader["Naziv"].ToString(),
                    ProsecnaOcena = (double)reader["ProsecnaOcena"],
                };

                apartmani.Add(apartman);
            }

            reader.Close();

            return apartmani;
        }

        public void Update(string propertyName, object newProp, IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update {entity.TableName} " +
                $"set {propertyName} = {newProp} " +
                $"where {entity.GetIdQuery()}";
            command.ExecuteNonQuery();

        }


    }
}
