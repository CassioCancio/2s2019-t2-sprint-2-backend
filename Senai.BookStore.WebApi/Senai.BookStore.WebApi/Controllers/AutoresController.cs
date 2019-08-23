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
    public class AutoresController : ControllerBase
    {
        AutorRepository AutorRepository = new AutorRepository();

        [HttpGet]
        public IEnumerable<AutorModel> Listar()
        {
            return AutorRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(AutorModel autorModel)
        {
            AutorRepository.Cadastrar(autorModel);
            return Ok();
        }
    }
}