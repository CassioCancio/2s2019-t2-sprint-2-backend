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
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(ArtistaRepository.Listar());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            try
            {
                ArtistaRepository.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }
    }
}