using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_BookStore.WebApi.Models;
using Senai.M_BookStore.WebApi.Repositories;

namespace Senai.M_BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        LivroRepository LivroRepository = new LivroRepository();

        [HttpGet]
        public IEnumerable<LivroModel> Listar()
        {
            return LivroRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            LivroModel Genero = LivroRepository.BuscarPorId(id);
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        [HttpPost]
        public IActionResult Cadastrar(LivroModel livroModel)
        {
            LivroRepository.Cadastrar(livroModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, LivroModel livroModel)
        {
            livroModel.IdLivro = id;
            LivroRepository.Alterar(livroModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LivroRepository.Deletar(id);
            return Ok();
        }

    }
}