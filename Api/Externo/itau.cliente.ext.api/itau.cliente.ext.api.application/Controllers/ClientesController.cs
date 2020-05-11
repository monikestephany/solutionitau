using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itau.cliente.ext.api.core.Contracts;
using itau.cliente.ext.api.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itau.cliente.ext.api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IRabbitService _rabbitService;
        private readonly ILogger<ClientesController> logger;
      public ClientesController(IRabbitService rabbitService, ILogger<ClientesController> logger)
        {
            _rabbitService = rabbitService;
            this.logger = logger;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                return Created("Post", _rabbitService.AddQueue(cliente));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}