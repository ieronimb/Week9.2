using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Week9._2.DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly SqlConnection Connection;

        protected BaseRepository(SqlConnection connection)
        {
            this.Connection = connection;
        }
    }
}
