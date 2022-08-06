using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteOpea.ClientesAPI.DTO;
using TesteOpea.ClientesAPI.Repository;

namespace TesteOpea.ClientesAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repositorio;

        public ClienteController(IClienteRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> BuscaClientes()
        {
            var clientes = await _repositorio.BuscaClientes();
            if (clientes == null) return NotFound("Não existe Dados de Clientes na Base de Dados!");
            return Ok(clientes);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> BuscaClientePorId(long id)
        {
            var cliente = await _repositorio.BuscaClientePorId(id);
            if (cliente == null) return NotFound("Cliente não encontrado");
            return Ok(cliente);
        }


        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Create([FromBody] ClienteDTO cli)
        {

            if (cli == null) return BadRequest("Dados Inválidos, favor verificar!");
            var cliente = await _repositorio.Criar(cli);
            return Ok(cliente);
        }


        [HttpPut]
        public async Task<ActionResult<ClienteDTO>> Update([FromBody] ClienteDTO cli)
        {

            if (cli == null) return BadRequest("Dados Inválidos, favor verificar!");
            var cliente = await _repositorio.Atualizar(cli);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteDTO>> Delete(long id)
        {
            var status = await _repositorio.Apagar(id);
            if (!status)
                return BadRequest("Cliente não encontrado!");
            else
                return Ok(status);

        }
    }
}
