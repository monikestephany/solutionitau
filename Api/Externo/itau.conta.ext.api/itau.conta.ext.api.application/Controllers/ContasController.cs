using System;
using itau.conta.ext.api.core.Contracts;
using itau.conta.ext.api.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itau.conta.ext.api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IRabbitService _rabbitService;
        private readonly ILogger<ContasController> logger;
      public ContasController(IRabbitService rabbitService, ILogger<ContasController> logger)
        {
            _rabbitService = rabbitService;
            this.logger = logger;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Conta conta)
        {
            try
            {
                return Created("Post", _rabbitService.AddQueue(conta));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}