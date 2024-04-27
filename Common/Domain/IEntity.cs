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
        BindingList<IEntity> GetReaderList(SqlDataReader reader);
        void PrepareCommand(SqlCommand cmd);
    }
}
