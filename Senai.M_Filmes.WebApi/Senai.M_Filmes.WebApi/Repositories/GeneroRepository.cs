using Senai.M_Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        //List<GeneroDomain> generos = new List<GeneroDomain>()
        //{
        //    new GeneroDomain { IdGenero = 1, Nome = "Teen" }
        //    ,new GeneroDomain { IdGenero = 2, Nome = "Enigma" }
        //};
        
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_RoteiroFilmes;User Id=sa;Pwd=132;";
        
        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="genero"></param>
        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // declara o comando com a query e a conexao
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                // abre a conexao
                con.Open();
                // executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @IdGenero";

            // aonde, em qual local
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }

                    return null;
                }
            }

        }

        public List<GeneroDomain> Listar()
        {

            List<GeneroDomain> generos = new List<GeneroDomain>();

            // abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // fazer a leitura de todos os registros
                // declarar a instrucao a ser realizada
                string Query = "SELECT IdGenero, Nome FROM Generos ORDER BY Nome DESC";

                // abre a conexao com o bd
                con.Open();
                // declaro para percorrer a lista
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }

                }

            }

            // devolver a lista preenchida
            return generos;
        }

        // update
        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // faco o comando
                SqlCommand cmd = new SqlCommand(Query, con);
                // defino os parametros
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", generoDomain.IdGenero);
                // abrir a conexao
                con.Open();
                // executar
                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            // conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // comando
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                // executar
                cmd.ExecuteNonQuery();
            }
        }

        public List<FilmeDomain> BuscarPorIdGenero(int id)
        {

            List<FilmeDomain> filmes = new List<FilmeDomain>();

            string Query = "SELECT F.IdFilme, F.Titulo, F.IdGenero, G.Nome FROM Filmes F INNER JOIN Generos G ON G.IdGenero = F.IdGenero WHERE G.IdGenero = @Id";

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
                                filmes.Add(filme);
                            return filmes;
                        }
                    }
                    return null;
                }
            }

        }

    }
}
