using Senai.Peoples.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionarioModel> Listar()
        {
            List<FuncionarioModel> funcionarios = new List<FuncionarioModel>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios ORDER BY Nome DESC";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioModel funcionario = new FuncionarioModel
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }

                }

            }
            return funcionarios;
        }

        public void Cadastrar(FuncionarioModel funcionario)
        {
            string Query = "INSERT INTO Funcionarios (Nome,Sobrenome) VALUES (@Nome,@Sobrenome)";

                using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
}

        public FuncionarioModel BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @id";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioModel funcionario = new FuncionarioModel
                            {
                                IdFuncionario= Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }

                    return null;
                }
            }

        }

        public FuncionarioModel BuscarPorNome(string nome)
        {
            string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE Nome = @nome";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioModel funcionario = new FuncionarioModel
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }

                    return null;
                }
            }

        }

        public void Alterar(FuncionarioModel funcionarioModel)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioModel.Nome);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioModel.IdFuncionario);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int id)
{
    string Query = "DELETE FROM Funcionarios WHERE IdFuncionario= @IdFuncionario";
    using (SqlConnection con = new SqlConnection(StringConexao))
    {
        SqlCommand cmd = new SqlCommand(Query, con);
        cmd.Parameters.AddWithValue("@IdFuncionario", id);
        con.Open();
        cmd.ExecuteNonQuery();
    }
}
    }
}

