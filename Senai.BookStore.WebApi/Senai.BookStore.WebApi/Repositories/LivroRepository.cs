using Senai.M_BookStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_BookStore.WebApi.Repositories
{
    public class LivroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132;";

        public void Cadastrar(LivroModel livro)
        {
            string Query = "INSERT INTO Livros (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", livro.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public LivroModel BuscarPorId(int id)
        {
            string Query = "SELECT IdLivro, Nome FROM Livros WHERE IdLivro = @IdLivro";

            // aonde, em qual local
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdLivro", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LivroModel livro = new LivroModel
                            {
                                IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return livro;
                        }
                    }

                    return null;
                }
            }

        }

        public List<LivroModel> Listar()
        {

            List<LivroModel> livros = new List<LivroModel>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT L.IdLivro, L.Titulo, L.Descricao, L.IdAutor, L.IdGenero, Generos.Descricao, Autores.Nome,Autores.DataNascimento FROM Livros inner join Autores ON Livros.IdAutor = Autores.IdAutor INNER JOIN Generos on Livros.IdGenero = Generos.IdGenero";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        LivroModel livro = new LivroModel
                        {
                            IdLivro = Convert.ToInt32(rdr["L.IdLivro"]),
                            Titulo = rdr["L.Titulo"].ToString(),
                            Genero = new GeneroModel
                            {
                                IdGenero = Convert.ToInt32(rdr["G.IdGenero"]),
                                Descricao = rdr["L.Descricao"].ToString()
                            },
                            Autor = new AutorModel
                            {
                            }
                            
                        };
                        livros.Add(livro);
                    }

                }

            }

            return livros;
        }

        // update
        public void Alterar(LivroModel livroModel)
        {
            string Query = "UPDATE Livros SET Titulo = @Nome WHERE IdLivro = @IdLivro";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", livroModel.Titulo);
                cmd.Parameters.AddWithValue("@IdLivro", livroModel.IdLivro);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Livros WHERE IdLivro = @IdLivro";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdLivro", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
