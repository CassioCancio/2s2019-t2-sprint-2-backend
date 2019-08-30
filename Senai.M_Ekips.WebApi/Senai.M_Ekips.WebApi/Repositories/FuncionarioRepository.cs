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
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_Ekips; User Id=sa;Pwd=132";

        public List<Funcionarios> Listar()
        {
            List<Funcionarios> ListaDeFuncionarios = new List<Funcionarios>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string query = "select f.IdFuncionario, f.Nome, f.CPF, f.DataNascimento, f.Salario, f.IdDepartamento, f.IdCargo, f.IdUsuario, u.Email, u.Senha, u.IdPermissao, d.Nome, c.Nome, c.IdStatus from Funcionarios f inner join Usuarios u on f.IdUsuario = u.IdUsuario inner join Departamentos d on f.IdDepartamento = d.IdDepartamento inner join Cargos c on f.IdCargo = c.IdCargo";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Funcionarios funcionario = new Funcionarios
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Cpf = sdr["CPF"].ToString(),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                            Salario = Convert.ToDouble(sdr["Salario"]),
                            IdDepartamentoNavigation = new Departamentos
                            {
                                IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                                Nome = sdr["Nome"].ToString()
                            },
                            IdCargoNavigation = new Cargos
                            {
                                IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                                Nome = sdr["Nome"].ToString(),
                                IdStatus = Convert.ToInt32(sdr["IdStatus"])
                            },
                            IdUsuario = Convert.ToInt32(sdr["IdUsuario"])
                        };
                        ListaDeFuncionarios.Add(funcionario);
                    }
                }
            }

            return ListaDeFuncionarios;
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
                string Query = "select f.IdFuncionario, f.Nome, f.CPF, f.DataNascimento, f.Salario, f.IdDepartamento, f.IdCargo, f.IdUsuario, u.Email, u.Senha, u.IdPermissao, d.Nome, c.Nome, c.IdStatus from Funcionarios f inner join Usuarios u on f.IdUsuario = u.IdUsuario inner join Departamentos d on f.IdDepartamento = d.IdDepartamento inner join Cargos c on f.IdCargo = c.IdCargo WHERE f.IdUsuario = @id";

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
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Cpf = rdr["CPF"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"]),
                            Salario = Convert.ToDouble(rdr["Salario"]),
                            IdDepartamentoNavigation = new Departamentos
                            {
                                IdDepartamento = Convert.ToInt32(rdr["IdDepartamento"]),
                                Nome = rdr["Nome"].ToString()
                            },
                            IdCargoNavigation = new Cargos
                            {
                                IdCargo = Convert.ToInt32(rdr["IdCargo"]),
                                Nome = rdr["Nome"].ToString(),
                                IdStatus = Convert.ToInt32(rdr["IdStatus"])
                            },
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])
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

