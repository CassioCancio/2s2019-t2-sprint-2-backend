using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    

    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();


        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos(IAuthorizeData authorizeData)
        {
            int IdPermissao = int.Parse(authorizeData.Roles);

            if (IdPermissao == 1)
                return Ok(FuncionarioRepository.Listar());

            else
                return BadRequest();
                    
                    //Ok(FuncionarioRepository.BuscarPorId(authorizeData))
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            try
            {
                FuncionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Atualizar(Funcionarios funcionario)
        {
            try
            {
                Funcionarios FuncionarioBuscada = FuncionarioRepository.BuscarPorId
                    (funcionario.IdFuncionario);
                if (FuncionarioBuscada == null)
                    return NotFound();

                FuncionarioRepository.Atualizar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }
    }

}
