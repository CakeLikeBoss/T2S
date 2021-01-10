using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DatabaseInfo;

namespace T2S.Models
{
    public class ConteinerTipo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
    }

    public class ConteinerTipoModel : IDisposable
    {
        private SqlConnection connection;
        private Database database;

        public ConteinerTipoModel()
        {
            database = new Database();
            connection = database.Connection();
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }


        public List<ConteinerTipo> Read()
        {
            List<ConteinerTipo> lista = new List<ConteinerTipo>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT 
	                Id,
	                Tipo
	            FROM ConteinerTipo";

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                ConteinerTipo conteinerTipo = new ConteinerTipo();

                conteinerTipo.Id = (int)reader["Id"];
                conteinerTipo.Tipo = (string)reader["Tipo"];
                
                lista.Add(conteinerTipo);
            }

            return lista;
        }

    }
}