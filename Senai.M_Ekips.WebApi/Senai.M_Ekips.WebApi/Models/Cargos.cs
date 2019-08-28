using System;
using System.Collections.Generic;

namespace Senai.M_Ekips.WebApi.Models
{
    public partial class Cargos
    {
        public Cargos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdCargo { get; set; }
        public string Nome { get; set; }
        public int IdStatus { get; set; }

        public Status IdStatusNavigation { get; set; }
        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
