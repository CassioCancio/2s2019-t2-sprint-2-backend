using Senai.Guffos.WebApi.Domains;
using Senai.Guffos.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Guffos.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                return UsuarioBuscado;
            }
        }
    }
}
