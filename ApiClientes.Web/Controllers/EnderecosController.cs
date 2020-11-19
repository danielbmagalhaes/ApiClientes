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
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _service;
        private readonly IClienteService _serviceCliente;

        public EnderecosController(IEnderecoService service, IClienteService serviceCliente)
        {
            _service = service;
            _serviceCliente = serviceCliente;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnderecoDTO>>> Get()
        {
            var enderecos = await _service.GetAll();

            return new OkObjectResult(enderecos);
        }

        [HttpGet("{id}", Name = "ObterEndereco")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EnderecoDTO>> Get(int id)
        {
            var EnderecoEncontrado = await _service.Get(id);

            if (EnderecoEncontrado == null) return NotFound();

            return new OkObjectResult(EnderecoEncontrado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post([FromBody] EnderecoDTO endereco)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var dono = await _serviceCliente.Get(endereco.ClienteId);
            if (dono == null) return BadRequest("Dono do Endereço inválido");

            var enderecoInserido = await _service.Add(endereco);
            var enderecoEncontrado = await _service.Get(enderecoInserido.Id);
            return new CreatedAtRouteResult("ObterEndereco", new { id = enderecoEncontrado.Id }, enderecoEncontrado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(int id, [FromBody] EnderecoDTO endereco)
        {
            if (id != endereco.Id) return BadRequest();
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            
            var dono = _serviceCliente.Get(endereco.ClienteId);
            if (dono == null) return BadRequest("Dono do Endereço inválido");

            var EnderecoEncontrado = await _service.Get(id);
            if (EnderecoEncontrado == null) return NotFound();

            await _service.Update(endereco);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EnderecoDTO>> Delete(int id)
        {
            var EnderecoEncontrado = await _service.Get(id);

            if (EnderecoEncontrado == null) return NotFound();

            await _service.Delete(EnderecoEncontrado);

            return new OkObjectResult(EnderecoEncontrado);           
        }
    }
}
