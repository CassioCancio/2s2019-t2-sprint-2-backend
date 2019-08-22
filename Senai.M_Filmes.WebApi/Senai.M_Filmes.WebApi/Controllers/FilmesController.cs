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
    [ApiController]
    public class FilmesController : ControllerBase
    {
        FilmeRepository FilmeRepository = new FilmeRepository();

        // GET /api/generos
        [HttpGet]
        public IEnumerable<FilmeDomain> Listar()
        {
            // return generos;
            return FilmeRepository.Listar();
        }

        // GET /api/generos/1
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            // lista fixa
            // FilmeDomain Genero = generos.Find(x => x.IdGenero == id);

            // do banco de dados
            FilmeDomain Filme = FilmeRepository.BuscarPorId(id);
            if (Filme == null)
            {
                return NotFound();
            }
            return Ok(Filme);
        }

        // POST /api/generos
        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filmeDomain)
        {
            try
            {
                FilmeRepository.Cadastrar(filmeDomain);
                return Ok();
            }
            catch (Exception ex)
            {
                // nao foi realizada com sucesso.
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }

    }
}