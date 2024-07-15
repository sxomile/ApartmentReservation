using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//svaki ovaj BindingList posle da prepakujem u List
//kako ovde tako i u sistemskim operacijama
//nema puno smisla

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
            command.CommandText = $"select * from [{entity.TableName}]";
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

        //ova metoda radi posao, ali promeniti posle ovo searchProp i value nekako 
        //da bude jos jednostavnije
        //glupo da se one gluposti pisu u SO, komplikovano bespotrebno
        //lepo za broker msm ali dok neko skonta kako query da formira ima da crkne
        public BindingList<IEntity> GetAllWithFilter(IEntity entity, string searchProp, string value)
        {

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"select * from [{entity.TableName}] where {searchProp} like {value}";
			SqlDataReader reader = cmd.ExecuteReader();
			BindingList<IEntity> list = entity.GetReaderList(reader);
			cmd.Dispose();
            return list;

		}

        public int AddWithId(IEntity entity)
        {
			int id = 0;
			SqlCommand cmd = connection.CreateCommand();
			cmd.CommandText = $"insert into {entity.TableName} values {entity.Values} select scope_identity() as [scope]";
			entity.PrepareCommand(cmd);
			object result = cmd.ExecuteScalar();
			if (result != null && result != DBNull.Value)
			{
				id = Convert.ToInt32(result);
			}
			cmd.Dispose();
			return id;
		}

        //ovaj moze da prodje
        public IEntity GetEntityById(IEntity obj, string use = "")
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select top 1 * from [{obj.TableName}] where {obj.GetIdQuery(use)}";
            SqlDataReader reader = command.ExecuteReader();
            obj.SetValues(obj, reader);
            return obj;
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