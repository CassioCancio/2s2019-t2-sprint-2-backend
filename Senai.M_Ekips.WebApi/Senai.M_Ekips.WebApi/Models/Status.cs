using System;
using System.Collections.Generic;

namespace Senai.M_Ekips.WebApi.Models
{
    public partial class Status
    {
        public Status()
        {
            Cargos = new HashSet<Cargos>();
        }

        public int IdStatus { get; set; }
        public string Nome { get; set; }

        public ICollection<Cargos> Cargos { get; set; }
    }
}
