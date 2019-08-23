using Senai.M_BookStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_BookStore.WebApi.Repositories
{
    public class AutorRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132;";

        public List<AutorModel> Listar()
        {

            List<AutorModel> autores = new List<AutorModel>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdAutor, Nome, Email, Ativo, DataNascimento FROM Autores";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AutorModel autor = new AutorModel
                        {
                            IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Ativo = Convert.ToBoolean(rdr["Ativo"]),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"].ToString())
                        };
                        autores.Add(autor);
                    }
                }
            }
            return autores;
        }

        public void Cadastrar(AutorModel autor)
        {
            string Query = "INSERT INTO Autores (Nome, Email, DataNascimento) VALUES (@Nome,@Email,@DataNascimento)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", autor.Nome);
                cmd.Parameters.AddWithValue("@Email", autor.Email);
                cmd.Parameters.AddWithValue("@DataNascimento", autor.DataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
