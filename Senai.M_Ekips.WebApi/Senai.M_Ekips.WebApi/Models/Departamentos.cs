using System;
using System.Collections.Generic;

namespace Senai.M_Ekips.WebApi.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
