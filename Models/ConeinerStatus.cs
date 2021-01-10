using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DatabaseInfo;

namespace T2S.Models
{
    public class ConteinerStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class ConteinerStatusModel : IDisposable
    {
        private SqlConnection connection;
        private Database database;

        public ConteinerStatusModel()
        {
            database = new Database();
            connection = database.Connection();
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }


        public List<ConteinerStatus> Read()
        {
            List<ConteinerStatus> lista = new List<ConteinerStatus>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT 
	                Id,
	                Status
	            FROM ConteinerStatus";

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                ConteinerStatus conteinerStatus = new ConteinerStatus();

                conteinerStatus.Id = (int)reader["Id"];
                conteinerStatus.Status = (string)reader["Status"];

                lista.Add(conteinerStatus);
            }

            return lista;
        }

    }
}