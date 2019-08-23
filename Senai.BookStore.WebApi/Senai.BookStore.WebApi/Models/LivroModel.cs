using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.M_BookStore.WebApi.Models
{
    public class LivroModel
    {
        public int IdLivro {get;set;}
        public string Titulo {get;set;}
        public string Descricao {get;set;}
        public AutorModel Autor {get;set;}
        public GeneroModel Genero {get;set;}
    }
}
