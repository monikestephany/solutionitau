using System;
using itau.pos.ext.api.core.Contracts;
using itau.pos.ext.api.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itau.pos.ext.api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PossController : ControllerBase
    {
        private readonly IRabbitService _rabbitService;
        private readonly ILogger<PossController> logger;
      public PossController(IRabbitService rabbitService, ILogger<PossController> logger)
        {
            _rabbitService = rabbitService;
            this.logger = logger;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Pos pos)
        {
            try
            {
                return Created("Post", _rabbitService.AddQueue(pos));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}