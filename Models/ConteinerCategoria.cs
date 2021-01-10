using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DatabaseInfo;

namespace T2S.Models
{
    public class ConteinerCategoria
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
    }

    public class ConteinerCategoriaModel : IDisposable
    {
        private SqlConnection connection;
        private Database database;

        public ConteinerCategoriaModel()
        {
            database = new Database();
            connection = database.Connection();
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }


        public List<ConteinerCategoria> Read()
        {
            List<ConteinerCategoria> lista = new List<ConteinerCategoria>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT 
	                Id,
	                Categoria
	            FROM ConteinerCategoria";

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                ConteinerCategoria conteinerCategoria = new ConteinerCategoria();

                conteinerCategoria.Id = (int)reader["Id"];
                conteinerCategoria.Categoria = (string)reader["Categoria"];

                lista.Add(conteinerCategoria);
            }

            return lista;
        }

    }
}