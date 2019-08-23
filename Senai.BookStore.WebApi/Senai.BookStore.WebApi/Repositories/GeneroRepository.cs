using Senai.M_BookStore.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.M_BookStore.WebApi.Controllers
{
    internal class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore;User Id=sa;Pwd=132;";
        public List<GeneroModel> Listar()
        {
            List<GeneroModel> generos = new List<GeneroModel>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Descricao FROM Generos";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroModel autor = new GeneroModel
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Descricao = rdr["Descricao"].ToString(),
                        };
                        generos.Add(autor);
                    }
                }
            }
            return generos;
        }

        public void Cadastrar(GeneroModel genero)
        {
            string Query = "INSERT INTO Generos (Descricao) VALUES (@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Descricao);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}