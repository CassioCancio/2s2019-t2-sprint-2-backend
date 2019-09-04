using Senai.M_AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_AutoPecas.WebApi.Interfaces
{
    interface IPecaRepository
    {
        List<Pecas> Listar();

        Pecas BuscarPorId(int id);

        void Cadastrar(Pecas peca);

        void Alterar(Pecas peca);

        void Deletar(int id);
    }
}
