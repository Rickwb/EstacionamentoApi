using EstacionamentoApi.DTOS;
using EstacionamentoApi.Entidades;
using EstacionamentoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class EstacionamentoController : Controller
    {
        private EstacionamentoService _estacionamentoService;
        private ClienteService _clienteService;
        public EstacionamentoController(EstacionamentoService estacionamentoService,ClienteService clienteService)
        {
            _estacionamentoService = estacionamentoService;
            _clienteService = clienteService;
        }
        public IActionResult CadastraCliente(ClienteDTO clienteDTO)
        {
            if (!clienteDTO.Valido)
                return BadRequest("Cliente Invalido");

            var cliente = new Cliente(
                cpf: clienteDTO.Nome,
                veiculo: new Carro("01245789"));

                return View();
        }
    }
}
