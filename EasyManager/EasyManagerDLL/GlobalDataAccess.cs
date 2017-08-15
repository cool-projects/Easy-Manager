using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EasyManagerDLL
{
    public static class GlobalDataAccess
    {
        //public static readonly string ConnectionString = "workstation id=EasyManager.mssql.somee.com;packet size=4096;user id=EasyManager_SQLLogin_1;pwd=ds7ps7bnig;data source=EasyManager.mssql.somee.com;persist security info=False;initial catalog=EasyManager";
        //public static readonly string ConnectionString = "server=JVMSE\\SQLMAIN;database=EasyManager;Integrated Security=True;";
        public static readonly string ConnectionString = "data source=197.242.150.84;initial catalog=EasyManager;user id=emadmin;password=P@ssword1;";

        public static SqlDataReader ExecuteReader(SqlCommand command)
        {
            var connection = command.Connection;
            connection.Open();
            // CommandBehavior.CloseConnection tells the reader to close the connection when it's closed itself
            return command.ExecuteReader();
        }
        public static int ExecuteNonQuery(SqlCommand command)
        {
            var connection = command.Connection;
            connection.Open();
            // CommandBehavior.CloseConnection tells the reader to close the connection when it's closed itself
            return command.ExecuteNonQuery();
        }
        public static SqlCommand CreateSpCommand(string name, SqlConnection connection)
        {
            var command = new SqlCommand(name, connection) { CommandType = CommandType.StoredProcedure };
            return command;
        }

        public static SqlConnection CreateSqlConnection()
        {
            if (ConnectionString == null)
                throw new Exception("No connection string set");
            return new SqlConnection(ConnectionString);
        }
    }
}
