using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_Filmes.WebApi.Domains;
using Senai.M_Filmes.WebApi.Repositories;

namespace Senai.M_Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        List<GeneroDomain> generos = new List<GeneroDomain>()
        {
            new GeneroDomain { IdGenero = 1, Nome = "Rock" }
            ,new GeneroDomain { IdGenero = 2, Nome = "Pop" }
        };

        GeneroRepository GeneroRepository = new GeneroRepository();

        // GET /api/generos
        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            // return generos;
            return GeneroRepository.Listar();
        }

        // GET /api/generos/1
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // lista fixa
            // GeneroDomain Genero = generos.Find(x => x.IdGenero == id);

            // do banco de dados
            GeneroDomain Genero = GeneroRepository.BuscarPorId(id);
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        // POST /api/generos
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            // do banco de dados
            GeneroRepository.Cadastrar(generoDomain);
            return Ok();
        }

        // ATUALIZAR
        // PUT /api/generos
        // { "idGeneroMusical" : "", "nome" : ""}
        // PUT /api/generos/1 {"nome" : "Genero A"}
        [HttpPut]
        public IActionResult Atualizar(GeneroDomain generoDomain)
        {
            GeneroRepository.Alterar(generoDomain);
            return Ok();
        }

        // DELETAR
        // DELETE /api/generos/1009
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição Recebida";
        //}


    }
}