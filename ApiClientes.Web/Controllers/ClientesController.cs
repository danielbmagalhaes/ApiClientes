using ApiClientes.App.Models.DTOs;
using ApiClientes.App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ApiClientes.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get()
        {
            var clientes = await _service.GetAll();

            return new OkObjectResult(clientes);
        }

        [HttpGet("{id}", Name = "ObterCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var clienteEncontrado = await _service.Get(id);

            if (clienteEncontrado == null) return NotFound();

            //return clienteEncontrado;
            return new OkObjectResult(clienteEncontrado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] ClienteDTO cliente)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var clienteInserido = await _service.Add(cliente);
            return new CreatedAtRouteResult("ObterCliente", new { id = clienteInserido.Id }, clienteInserido);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO cliente)
        {
            if (id != cliente.Id) return BadRequest();

            var clienteEncontrado = await _service.Get(id);
            if (clienteEncontrado == null) return NotFound();

            await _service.Update(cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ClienteDTO>> Delete(int id)
        {
            var clienteEncontrado = await _service.Get(id);

            if (clienteEncontrado == null) return NotFound();

            await _service.Delete(clienteEncontrado);

            return new OkObjectResult(clienteEncontrado);
        }
    }
}
