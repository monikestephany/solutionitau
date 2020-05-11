using AutoMapper;
using itau.conta.api.application.Model;
using itau.conta.api.core.Contracts.Services;
using itau.conta.api.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itau.conta.api.application.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaService contaService;
        private readonly ILogger<ContasController> logger;
        private readonly IMapper mapper;
        public ContasController(IContaService contaService, ILogger<ContasController> logger, IMapper mapper)
        {
            this.contaService = contaService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = contaService.GetAll();
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

        // POST: api/Contas
        [HttpPost]
        public IActionResult Post([FromBody] ContaCreateModel conta)
        {
            try
            {
                return Created("Post", contaService.Create(mapper.Map<Conta>(conta)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Contas/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ContaUpdateModel conta)
        {
            try
            {
                return Ok(contaService.Update(id, mapper.Map<Conta>(conta)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        // PUT: api/Contas/5
        [HttpPut("alterar-senha")]
        public IActionResult PutSenha(string id,int senha)
        {
            try
            {
                return Ok(contaService.UpdateSenha(id, senha));
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
                contaService.Delete(id);
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
