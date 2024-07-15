using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName {  get; }
        string Values {  get; }
        string GetIdQuery(string use = "");
        BindingList<IEntity> GetReaderList(SqlDataReader reader);
        void PrepareCommand(SqlCommand cmd);
        void SetValues(IEntity entity, SqlDataReader reader);
        bool Validate(IEntity entity, List<IEntity> entities);
    }
}
