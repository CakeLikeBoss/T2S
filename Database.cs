using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace DatabaseInfo
{
    public class Database
    {
        private string server;
        private string database;
        private string user;
        private string password;
        private SqlConnection connection;

        public Database()
        {
            server = @"DESKTOP-8CVORGN\SQLEXPRESS";
            database = "T2S";
            user = "sa";
            password = "miojo_cozido";
        }

        public SqlConnection Connection()
        {
            string strConn = @"Server=" + server + ";Database=" + database + ";User Id=" + user + ";Password=" + password + ";";
            connection = new SqlConnection(strConn);
            return connection;
        }
    }
}