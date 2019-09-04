using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.M_AutoPecas.WebApi.Interfaces;
using Senai.M_AutoPecas.WebApi.Repositories;

namespace Senai.M_AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecaRepository PecaRepository { get; set; }

        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }
    }
}