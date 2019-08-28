using System;
using System.Collections.Generic;

namespace Senai.M_Ekips.WebApi.Models
{
    public partial class Permissoes
    {
        public Permissoes()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPermissao { get; set; }
        public string TipoPermissao { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
