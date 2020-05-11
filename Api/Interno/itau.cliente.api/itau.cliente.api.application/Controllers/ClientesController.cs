using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using itau.cliente.api.application.Model;
using itau.cliente.api.core.Contracts.Services;
using itau.cliente.api.core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace itau.cliente.api.application.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;
        private readonly ILogger<ClientesController> logger;
        private readonly IMapper mapper;
        public ClientesController(IClienteService clienteService, ILogger<ClientesController> logger, IMapper mapper)
        {
            this.clienteService = clienteService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = clienteService.GetAll();
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

        [HttpGet("{cpf}", Name = "GetCPF")]
        public IActionResult GetCPF(string cpf)
        {
            try
            {
                var result = clienteService.GetCPF(cpf);
                if (result != null)
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

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Post([FromBody] ClienteCreateModel cliente)
        {      
            try
            {
                return Created("Post", clienteService.Create(mapper.Map<Cliente>(cliente)));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] ClienteUpdateModel cliente)
        {
            try
            {
                return Ok(clienteService.Update(id, mapper.Map<Cliente>(cliente)));
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
               clienteService.Delete(id);
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
