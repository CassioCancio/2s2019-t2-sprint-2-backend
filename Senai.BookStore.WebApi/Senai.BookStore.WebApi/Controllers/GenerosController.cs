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
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GeneroModel> Listar()
        {
            return GeneroRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroModel generoModel)
        {
            GeneroRepository.Cadastrar(generoModel);
            return Ok();
        }
    }
}