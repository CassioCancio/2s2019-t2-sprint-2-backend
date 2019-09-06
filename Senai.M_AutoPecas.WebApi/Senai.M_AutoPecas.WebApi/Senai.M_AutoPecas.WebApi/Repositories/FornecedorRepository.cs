using Senai.M_AutoPecas.WebApi.Domains;
using Senai.M_AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository
    {
        public int BuscarId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                var Fornecedor = ctx.Fornecedores.FirstOrDefault(x => x.IdFornecedor == id);
                return Fornecedor.IdFornecedor;
            }
        }
    }
}
