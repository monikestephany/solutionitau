using AutoMapper;
using itau.doc.api.application.Model;
using itau.doc.api.core.Contracts.Services;
using itau.doc.api.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.doc.api.application.Controllers
{
    [Route("api/docs")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly IDocService docService;
        private readonly ILogger<DocsController> logger;
        private readonly IMapper mapper;
        public DocsController(IDocService docService, ILogger<DocsController> logger, IMapper mapper)
        {
            this.docService = docService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = docService.GetAll();
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

        // POST: api/Docs
        [HttpPost]
        public IActionResult Post([FromBody] DocCreateModel doc)
        {
            try
            {
                return Created("Post", docService.Create(mapper.Map<Doc>(doc)));
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
                docService.Delete(id);
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
