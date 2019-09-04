using Senai.M_AutoPecas.WebApi.Domains;
using Senai.M_AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_AutoPecas.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
