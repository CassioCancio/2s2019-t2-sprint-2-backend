using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_AutoPecas.WebApi.Domains;
using Senai.M_AutoPecas.WebApi.Interfaces;
using Senai.M_AutoPecas.WebApi.Repositories;

namespace Senai.M_AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PecasController : ControllerBase
    {
        private IPecaRepository PecaRepository { get; set; }

        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            string IdUsuario = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int IntId = int.Parse(IdUsuario);

            return Ok(PecaRepository.Listar(IntId));
        }

        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            string IdUsuario = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int IntId = int.Parse(IdUsuario);

            try
            {
                PecaRepository.Cadastrar(peca, IntId);
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
            string IdUsuario = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int IntId = int.Parse(IdUsuario);

            Pecas Jogo = PecaRepository.BuscarPorId(id, IntId);
            if (Jogo == null)
                return NotFound();
            return Ok(Jogo);
        }
        
        [HttpPut("{id}")]
        public IActionResult Atualizar(Pecas peca, int id)
        {
            string IdUsuario = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int IntId = int.Parse(IdUsuario);

            try
            {
                Pecas JogoBuscado = PecaRepository.BuscarPorId
                    (id, IntId);
                if (JogoBuscado == null)
                    return NotFound();

                peca.IdPeca = id;
                PecaRepository.Alterar(peca, IntId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            string IdUsuario = User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
            int IntId = int.Parse(IdUsuario);

            PecaRepository.Deletar(id, IntId);
            return Ok();
        }
    }
}