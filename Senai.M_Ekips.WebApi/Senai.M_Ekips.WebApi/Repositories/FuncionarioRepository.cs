using Senai.M_Ekips.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<Funcionarios> Listar()
        {
            List<Funcionarios> funcionarios = new List<Funcionarios>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT F.IdFuncionario, F.Nome, F.CPF, F.Salario, F.DataNascimento, D.IdDepartamento,D.Nome, C.IdCargo, C.Nome FROM Funcionarios F INNER JOIN Departamentos D ON F.IdDepartamento = D.IdDepartamento INNER JOIN Cargos C ON F.IdCargo = C.IdCargo";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    // executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Funcionarios funcionario = new Funcionarios
                        {
                            IdFuncionario = Convert.ToInt32(rdr["F.IdFuncionario"]),
                            Nome = rdr["F.Nome"].ToString(),
                            Cpf = rdr["F.CPF"].ToString(),
                            Salario = Convert.ToDouble(rdr["F.Salario"]),
                            DataNascimento = Convert.ToDateTime(rdr["F.DataNascimento"]),
                            IdDepartamentoNavigation = new Departamentos
                            {
                                IdDepartamento = Convert.ToInt32(rdr["D.IdDepartamento"]),
                                Nome = rdr["D.Nome"].ToString()
                            },
                            IdCargoNavigation = new Cargos
                            {
                                IdCargo = Convert.ToInt32(rdr["C.IdCargo"]),
                                Nome = rdr["C.Nome"].ToString()
                            }
                        };
                        funcionarios.Add(funcionario);
                    };
                }
            }
            return funcionarios;
        }

        public void Cadastrar(Funcionarios estilo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(estilo);
                ctx.SaveChanges();
            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT F.IdFuncionario, F.Nome, F.CPF, F.Salario, F.DataNascimento, D.IdDepartamento,D.Nome, C.IdCargo, C.Nome FROM Funcionarios F INNER JOIN Departamentos D ON F.IdDepartamento = D.IdDepartamento INNER JOIN Cargos C ON F.IdCargo = C.IdCargo WHERE F.IdFuncionario = @id";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Funcionarios funcionario = new Funcionarios
                        {
                            IdFuncionario = Convert.ToInt32(rdr["F.IdFuncionario"]),
                            Nome = rdr["F.Nome"].ToString(),
                            Cpf = rdr["F.CPF"].ToString(),
                            Salario = Convert.ToDouble(rdr["F.Salario"]),
                            DataNascimento = Convert.ToDateTime(rdr["F.DataNascimento"]),
                            IdDepartamentoNavigation = new Departamentos
                            {
                                IdDepartamento = Convert.ToInt32(rdr["D.IdDepartamento"]),
                                Nome = rdr["D.Nome"].ToString()
                            },
                            IdCargoNavigation = new Cargos
                            {
                                IdCargo = Convert.ToInt32(rdr["C.IdCargo"]),
                                Nome = rdr["C.Nome"].ToString()
                            }
                        };
                        return funcionario;
                    };
                }
            }
            return null;
        }
    

        public void Atualizar(Funcionarios estilo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscada = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == estilo.IdFuncionario);
                FuncionarioBuscada.Nome = estilo.Nome;
                ctx.Funcionarios.Update(FuncionarioBuscada);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscada = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(FuncionarioBuscada);
                ctx.SaveChanges();
            }
        }
    }
}

