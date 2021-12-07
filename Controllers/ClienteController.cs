using EstacionamentoApi.DTOS;
using EstacionamentoApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EstacionamentoApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private ClienteService _clienteService;
        private EstacionamentoService _estacionamentoService;
        public ClienteController(ClienteService clienteService,EstacionamentoService estacionamentoService)
        {
            _clienteService = clienteService;
            _estacionamentoService = estacionamentoService;
        }
        [HttpPost,Route("/{idCliente}")]
        public IActionResult Pagar(Guid idCliente)
        {
            var cliente = _estacionamentoService.GetCliente(idCliente);
            return Ok(_clienteService.FinalizarPedido(cliente));
        }
    }
}
