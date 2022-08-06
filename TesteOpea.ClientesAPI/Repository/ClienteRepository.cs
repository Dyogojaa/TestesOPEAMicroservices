using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TesteOpea.ClientesAPI.DTO;
using TesteOpea.ClientesAPI.Model;
using TesteOpea.ClientesAPI.Model.Context;

namespace TesteOpea.ClientesAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly BDContext _context;
        private readonly IMapper _mapper;

        public ClienteRepository(BDContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> BuscaClientes()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            return _mapper.Map<List<ClienteDTO>>(clientes);

        }

        public async Task<ClienteDTO> BuscaClientePorId(long id)
        {
            Cliente cliente = await _context.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> Criar(ClienteDTO cliente)
        {
            Cliente cli = _mapper.Map<Cliente>(cliente);

            _context.Clientes.Add(cli); 
            await _context.SaveChangesAsync(); 

            return _mapper.Map<ClienteDTO>(cli);
        }

        public async Task<ClienteDTO> Atualizar(ClienteDTO cliente)
        {
            Cliente cli = _mapper.Map<Cliente>(cliente);

            _context.Clientes.Update(cli);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClienteDTO>(cli);
        }


        public async Task<bool> Apagar(long id)
        {
            try
            {
                Cliente cli = await _context.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (cli != null)
                {
                    _context.Clientes.Remove(cli);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        
    }
}
