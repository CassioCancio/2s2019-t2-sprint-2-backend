using System;
using Senai.M_Ekips.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.ToList();
            }

        }

        public void Cadastrar(Departamentos departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamentos.Add(departamento);
                ctx.SaveChanges();
            }
        }

        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }
    }
}
