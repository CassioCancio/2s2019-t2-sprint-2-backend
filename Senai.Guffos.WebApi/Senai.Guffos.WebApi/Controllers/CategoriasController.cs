using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Guffos.WebApi.Domains;
using Senai.Guffos.WebApi.Repositories;

namespace Senai.Guffos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();

        /// <summary>
        /// Listar todas as Categorias
        /// </summary>
        /// <returns> Retorna todas </returns>
        
        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId (int id)
        {
            Categorias Categoria = CategoriaRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }
        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                Categorias CategoriaBuscada = CategoriaRepository.BuscarPorId
                    (categoria.IdCategoria);
                if (CategoriaBuscada == null)
                    return NotFound();

                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch (Exception ex){
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            CategoriaRepository.Deletar(id);
            return Ok();
        }
    }
}