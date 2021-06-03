using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofillDatabase_0._0._1
{
    class DB
    {
        SqlConnection connection = new SqlConnection(
            @"Data Source = GFZHEL-PC121;" +
            /*"port=@port;" +
            "usernam=root;" +
            "password=root;" +
            "database=testDatabase"*/
            "Initial Catalog = testDatabase"

            );

         

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
