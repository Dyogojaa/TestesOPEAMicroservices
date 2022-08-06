using TesteOpea.ClientesFrontEnd.Models;

namespace TesteOpea.ClientesFrontEnd.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> BuscaTodosClientes();
        Task<ClienteViewModel> BuscaClientePorId(long id);
        Task<ClienteViewModel> CriarCliente(ClienteViewModel model);
        Task<ClienteViewModel> AtualizarCliente(ClienteViewModel model);
        Task<bool> ApagarClientePorId(long id);

    }
}
