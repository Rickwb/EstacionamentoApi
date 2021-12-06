using EstacionamentoApi.DTOS;
using EstacionamentoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class ClienteController : Controller
    {
        private ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public IActionResult CadastrarCliente(ClienteDTO clienteDTO)
        {
            if (clienteDTO.Valido)

            return View();
        }
    }
}
