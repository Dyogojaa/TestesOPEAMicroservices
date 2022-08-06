using TesteOpea.ClientesFrontEnd.Models;
using TesteOpea.ClientesFrontEnd.Services.Interfaces;
using TesteOpea.ClientesFrontEnd.Utils;

namespace TesteOpea.ClientesFrontEnd.Services
{
    public class ClienteService : IClienteService
    {

        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cliente";

        public ClienteService(HttpClient client)
        {
            _client = client ??
                throw new ArgumentNullException(nameof(client));
        }


        public async Task<IEnumerable<ClienteViewModel>> BuscaTodosClientes()
        {
            
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ClienteViewModel>>();

        }

        public async Task<ClienteViewModel> BuscaClientePorId(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ClienteViewModel>();
        }

        public async Task<ClienteViewModel> CriarCliente(ClienteViewModel model)
        {   
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ClienteViewModel>();
            else
                throw new Exception("Alguma coisa ocorreu ao executar a API");

        }

        public async Task<ClienteViewModel> AtualizarCliente(ClienteViewModel model)
        {
            
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ClienteViewModel>();
            else
                throw new Exception("Alguma coisa ocorreu ao executar a API");
        }

        public async Task<bool> ApagarClientePorId(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else
                throw new Exception("Alguma coisa ocorreu ao executar a API");
        }
    }
}
