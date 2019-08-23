using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_BookStore.WebApi.Models
{
    public class AutorModel
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
