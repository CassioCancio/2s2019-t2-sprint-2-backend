using Senai.M_AutoPecas.WebApi.Domains;
using Senai.M_AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_AutoPecas.WebApi.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }

        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.IdPeca == id);
            }
        }

        public void Alterar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscado = ctx.Pecas.FirstOrDefault(x => x.IdPeca == peca.IdPeca);
                PecaBuscado = peca;
                ctx.Pecas.Update(PecaBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscado = ctx.Pecas.Find(id);
                ctx.Pecas.Remove(PecaBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
