using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_Ekips.WebApi.Models;
using Senai.M_Ekips.WebApi.Repositories;

namespace Senai.M_Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    [Authorize]
    public class DepartamentosController : ControllerBase
    {
        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(DepartamentoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                DepartamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            Departamentos Departamento = DepartamentoRepository.BuscarPorId(id);
            if (Departamento == null)
                return NotFound();
            return Ok(Departamento);
        }
    }
}