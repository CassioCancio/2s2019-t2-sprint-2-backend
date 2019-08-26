using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Guffos.WebApi.Domains;
using Senai.Guffos.WebApi.Repositories;

namespace Senai.Guffos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventosController : ControllerBase
    {
        EventoRepository EventoRepository = new EventoRepository(); 
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(EventoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Eventos evento)
        {
            try
            {
                EventoRepository.Cadastrar(evento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }
    }
}