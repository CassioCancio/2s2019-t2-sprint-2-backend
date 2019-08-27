using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository EstiloRepository = new EstiloRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(EstiloRepository.Listar());
        }

        [Authorize (Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                EstiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            Estilos Estilo = EstiloRepository.BuscarPorId(id);
            if (Estilo == null)
                return NotFound();
            return Ok(Estilo);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos EstiloBuscada = EstiloRepository.BuscarPorId
                    (estilo.IdEstilo);
                if (EstiloBuscada == null)
                    return NotFound();

                EstiloRepository.Atualizar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
    }
}