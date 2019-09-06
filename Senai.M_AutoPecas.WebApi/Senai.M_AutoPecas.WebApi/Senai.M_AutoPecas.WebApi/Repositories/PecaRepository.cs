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
        FornecedorRepository FornecedorRepository = new FornecedorRepository();

        public List<Pecas> Listar(int idUsuario)
        {
            int idBuscado = FornecedorRepository.BuscarId(idUsuario);

            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Where(x => x.IdFonecedor == idBuscado).ToList();
            }
        }

        public void Cadastrar(Pecas peca, int idUsuario)
        {
            int idBuscado = FornecedorRepository.BuscarId(idUsuario);
            peca.IdFonecedor = idBuscado;

            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id, int idUsuario)
        {
            int idBuscado = FornecedorRepository.BuscarId(idUsuario);

            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.IdPeca == id && x.IdFonecedor == idBuscado);
            }
        }

        public bool Alterar(Pecas peca, int idUsuario)
        {
            int idBuscado = FornecedorRepository.BuscarId(idUsuario);

            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscado = ctx.Pecas.FirstOrDefault(x => x.IdPeca == peca.IdPeca);
                if (PecaBuscado.IdFonecedor == idBuscado)
                {
                    PecaBuscado = peca;
                    ctx.Pecas.Update(PecaBuscado);
                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Deletar(int id, int idUsuario)
        {
            int idBuscado = FornecedorRepository.BuscarId(idUsuario);

            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscado = ctx.Pecas.Find(id);
                if(PecaBuscado.IdFonecedor == idBuscado)
                {
                ctx.Pecas.Remove(PecaBuscado);
                ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
