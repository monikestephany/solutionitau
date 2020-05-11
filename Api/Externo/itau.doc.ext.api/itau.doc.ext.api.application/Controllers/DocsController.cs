using System;
using itau.doc.ext.api.core.Contracts;
using itau.doc.ext.api.core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itau.doc.ext.api.application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly IRabbitService _rabbitService;
        private readonly ILogger<DocsController> logger;
      public DocsController(IRabbitService rabbitService, ILogger<DocsController> logger)
        {
            _rabbitService = rabbitService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Doc doc)
        {
            try
            {
                return Created("Post", _rabbitService.AddQueue(doc));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}