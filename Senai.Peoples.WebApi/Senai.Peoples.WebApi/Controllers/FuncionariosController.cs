using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Models;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

       [HttpGet]
        public IEnumerable<FuncionarioModel> Listar()
        {
            return funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioModel funcionarioModel)
        {
            funcionarioRepository.Cadastrar(funcionarioModel);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioModel Genero = funcionarioRepository.BuscarPorId(id);
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        [HttpGet("{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            FuncionarioModel Genero = funcionarioRepository.BuscarPorNome(nome);
            if (Genero == null)
            {
                return NotFound();
            }
            return Ok(Genero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, FuncionarioModel funcionarioModel)
        {
            funcionarioModel.IdFuncionario = id;
            funcionarioRepository.Alterar(funcionarioModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }
    }
}