using TesteOpea.ClientesAPI.DTO;

namespace TesteOpea.ClientesAPI.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteDTO>> BuscaClientes();
        Task<ClienteDTO> BuscaClientePorId(long id);
        Task<ClienteDTO> Criar(ClienteDTO cliente);
        Task<ClienteDTO> Atualizar(ClienteDTO cliente);
        Task<bool> Apagar(long id);

    }
}
