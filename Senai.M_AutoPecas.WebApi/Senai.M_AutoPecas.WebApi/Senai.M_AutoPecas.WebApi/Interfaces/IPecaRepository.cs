using Senai.M_AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_AutoPecas.WebApi.Interfaces
{
    interface IPecaRepository
    {
        List<Pecas> Listar(int idUsuario);

        Pecas BuscarPorId(int idPeca, int idUsuario);

        void Cadastrar(Pecas peca, int idUsuario);

        bool Alterar(Pecas peca, int idUsuario);

        bool Deletar(int id, int idUsuario);
    }
}
