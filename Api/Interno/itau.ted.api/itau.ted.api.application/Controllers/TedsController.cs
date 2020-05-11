using AutoMapper;
using itau.ted.api.application.Model;
using itau.ted.api.core.Contracts.Services;
using itau.ted.api.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.ted.api.application.Controllers
{
    [Route("api/teds")]
    [ApiController]
    public class TedsController : ControllerBase
    {
        private readonly ITedService tedService;
        private readonly ILogger<TedsController> logger;
        private readonly IMapper mapper;
        public TedsController(ITedService tedService, ILogger<TedsController> logger, IMapper mapper)
        {
            this.tedService = tedService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = tedService.GetAll();
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

        // POST: api/Teds
        [HttpPost]
        public IActionResult Post([FromBody] TedCreateModel ted)
        {
            try
            {
                return Created("Post", tedService.Create(mapper.Map<Ted>(ted)));
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
                tedService.Delete(id);
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
