using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteOpea.ClientesFrontEnd.Models;
using TesteOpea.ClientesFrontEnd.Services.Interfaces;

namespace TesteOpea.ClientesFrontEnd.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.BuscaTodosClientes();            
            return View(clientes);
        }

        [HttpGet]
        public async Task<IActionResult> BuscaClienteId(int id)
        {

            var model = await _clienteService.BuscaClientePorId(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            PorteEmpresa();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Criar(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _clienteService.CriarCliente(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Atualizar(int id)
        {
            PorteEmpresa();
            var model = await _clienteService.BuscaClientePorId(id);
            if (model != null) return View(model);
            return NotFound();
        }

        
        [HttpPost]
        public async Task<IActionResult> Atualizar(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var response = await _clienteService.AtualizarCliente(model);
                if (response != null) return RedirectToAction(
                     nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Apagar(int id)
        {

            PorteEmpresa();
            var model = await _clienteService.BuscaClientePorId(id);

            if (model != null)
                return View(model);

            return NotFound();
        }


        [HttpPost]        
        public async Task<IActionResult> Apagar(ClienteViewModel  model)
        {            
            var response = await _clienteService.ApagarClientePorId(model.Id);
            if (response) return RedirectToAction(nameof(Index));
            return View(model);
        }


        private void PorteEmpresa()
        {
            var tipo = from porteEmpresa e in Enum.GetValues(typeof(porteEmpresa))
                       select new
                       {
                           Id = (int)e,
                           Name = e.ToString()
                       };

            ViewBag.PorteEmpresa = new SelectList(tipo, "Id", "Name");
        }

        public enum porteEmpresa : int
        {
            Pequena = 0,
            Media = 1,
            Grande = 2,
        }
    }
}
