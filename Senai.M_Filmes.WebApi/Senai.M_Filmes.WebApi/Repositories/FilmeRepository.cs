using Senai.M_Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {

        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<FilmeDomain> Listar()
        {

            List<FilmeDomain> filmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT F.IdFilme, F.Titulo, F.IdGenero, G.Nome FROM Filmes F INNER JOIN Generos G ON G.IdGenero = F.IdGenero";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        filmes.Add(filme);
                    };
                }
            }
            return filmes;
        }

        public void Cadastrar(FilmeDomain filme)
        {
            string Query = "INSERT INTO Filmes (Titulo,IdGenero) VALUES (@Titulo,@IdGenero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filme.GeneroId);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public FilmeDomain BuscarPorId(int id)
        {
            string Query = "SELECT F.IdFilme, F.Titulo, F.IdGenero, G.Nome FROM Filmes F INNER JOIN Generos G ON G.IdGenero = F.IdGenero WHERE F.IdFilme = @Id";

            // aonde, em qual local
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString()
                                }
                            };
                            return filme;
                        }
                    }

                    return null;
                }
            }

        }
    }
}


