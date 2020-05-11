using AutoMapper;
using itau.pos.api.application.Model;
using itau.pos.api.core.Contracts.Services;
using itau.pos.api.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.pos.api.application.Controllers
{
    [Route("api/pos")]
    [ApiController]
    public class PosController : ControllerBase
    {
        private readonly IPosService posService;
        private readonly ILogger<PosController> logger;
        private readonly IMapper mapper;
        public PosController(IPosService posService, ILogger<PosController> logger, IMapper mapper)
        {
            this.posService = posService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = posService.GetAll();
                if (result != null && result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // POST: api/Poss
        [HttpPost]
        public IActionResult Post([FromBody] PosCreateModel pos)
        {
            try
            {
                return Created("Post", posService.Create(mapper.Map<Pos>(pos)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                posService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
