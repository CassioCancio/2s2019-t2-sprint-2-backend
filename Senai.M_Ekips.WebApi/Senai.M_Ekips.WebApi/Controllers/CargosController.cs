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
    public class CargosController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(CargoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                CargoRepository.Cadastrar(cargo);
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
            Cargos Cargo = CargoRepository.BuscarPorId(id);
            if (Cargo == null)
                return NotFound();
            return Ok(Cargo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Cargos cargo, int id)
        {
            try
            {
                Cargos CargoBuscada = CargoRepository.BuscarPorId
                    (id);
                if (CargoBuscada == null)
                    return NotFound();

                cargo.IdCargo = id;
                CargoRepository.Atualizar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}