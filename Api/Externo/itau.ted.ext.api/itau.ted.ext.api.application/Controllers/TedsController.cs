using System;
using itau.ted.ext.api.core.Contracts;
using itau.ted.ext.api.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itau.ted.ext.api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TedsController : ControllerBase
    {
        private readonly IRabbitService _rabbitService;
        private readonly ILogger<TedsController> logger;
      public TedsController(IRabbitService rabbitService, ILogger<TedsController> logger)
        {
            _rabbitService = rabbitService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ted ted)
        {
            try
            {
                return Created("Post", _rabbitService.AddQueue(ted));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}