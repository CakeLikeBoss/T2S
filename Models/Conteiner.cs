using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DatabaseInfo;

namespace T2S.Models
{
    public class Conteiner
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public int CategoriaId { get; set; }
        public string Cliente { get; set; }
        public string Cntr { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
    }

    public class ConteinerModel : IDisposable
    {
        private SqlConnection connection;
        private Database database;

        public ConteinerModel()
        {
            database = new Database();
            connection = database.Connection();
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Conteiner conteiner)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Conteiner(Cliente,Cntr,Tipo,Status,Categoria) VALUES (@Cliente,@Cntr,@TipoId,@StatusId,@CategoriaId)";

            cmd.Parameters.AddWithValue("@Cliente", conteiner.Cliente);
            cmd.Parameters.AddWithValue("@Cntr", conteiner.Cntr);
            cmd.Parameters.AddWithValue("@TipoId", conteiner.TipoId);
            cmd.Parameters.AddWithValue("@StatusId", conteiner.StatusId);
            cmd.Parameters.AddWithValue("@CategoriaId", conteiner.CategoriaId);

            cmd.ExecuteNonQuery();
        }

        public void Update(Conteiner conteiner)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Conteiner SET  Cliente = @Cliente, Cntr = @Cntr, Tipo = @Tipo, Status = @Status, Categoria = @Categoria WHERE Id = @Id";

            cmd.Parameters.AddWithValue("@Id", conteiner.Id);
            cmd.Parameters.AddWithValue("@Cliente", conteiner.Cliente);
            cmd.Parameters.AddWithValue("@Cntr", conteiner.Cntr);
            cmd.Parameters.AddWithValue("@TipoId", conteiner.TipoId);
            cmd.Parameters.AddWithValue("@StatusId", conteiner.StatusId);
            cmd.Parameters.AddWithValue("@CategoriaId", conteiner.CategoriaId);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Conteiner conteiner)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Conteiner WHERE id = @Id";

            cmd.Parameters.AddWithValue("@Id", conteiner.Id);
            cmd.ExecuteNonQuery();
        }

        public List<Conteiner> Read()
        {
            List<Conteiner> lista = new List<Conteiner>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT 
	                c.Id,
                    c.Tipo as TipoId,
                    c.Status as StatusId,
                    c.Categoria as CategoriaId,
                    c.Cliente,
	                c.Cntr,
	                ct.Tipo,
	                cs.Status,
	                cc.Categoria
                FROM Conteiner c
                JOIN ConteinerTipo ct on c.Tipo = ct.Id
                JOIN ConteinerStatus cs on c.Status = cs.Id
                JOIN ConteinerCategoria cc on c.Categoria = cc.Id";

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Conteiner conteiner = new Conteiner();

                conteiner.Id = (int)reader["Id"];
                conteiner.TipoId = (int)reader["TipoId"];
                conteiner.StatusId = (int)reader["StatusId"];
                conteiner.CategoriaId = (int)reader["CategoriaId"];
                conteiner.Cliente = (string)reader["Cliente"];
                conteiner.Cntr = (string)reader["Cntr"];
                conteiner.Tipo = (string)reader["Tipo"];
                conteiner.Status = (string)reader["Status"];
                conteiner.Categoria = (string)reader["Categoria"];

                lista.Add(conteiner);
            }

            return lista;
        }

    }
}