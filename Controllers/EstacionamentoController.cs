using EstacionamentoApi.DTOS;
using EstacionamentoApi.Entidades;
using EstacionamentoApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EstacionamentoApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class EstacionamentoController : Controller
    {
        private EstacionamentoService _estacionamentoService;
        private ClienteService _clienteService;
        public EstacionamentoController(EstacionamentoService estacionamentoService, ClienteService clienteService)
        {
            _estacionamentoService = estacionamentoService;
            _clienteService = clienteService;
        }
        [HttpPost]
        public IActionResult CadastraCliente(ClienteDTO clienteDTO)
        {
            if (!clienteDTO.Valido)
                return BadRequest("Cliente Invalido");
            Cliente cliente;
            if (clienteDTO.Veiculo is Carro)
            {
                cliente = new Cliente(
                    cpf: clienteDTO.Nome,
                    veiculo: new Carro("01245789"));
            }
            else
            {
                cliente = new Cliente(
                   cpf: clienteDTO.Nome,
                   veiculo: new Moto(clienteDTO.Veiculo.Placa));

            }

            return Created("", _estacionamentoService.CadastrarCliente(cliente));
        }
        [HttpGet]
        public IActionResult BuscarTodosClientes()
        {
            return Ok(_estacionamentoService.GetAllClientes());
        }

        [HttpGet, Route("/{idCliente}")]
        public IActionResult BuscarClienteId(Guid id)
        {
            return Ok(_estacionamentoService.GetCliente(id));
        }

        [HttpPut, Route("/{idCliente}")]
        public IActionResult AtualizarCliente(Guid idCliente, ClienteDTO clienteDTO)
        {
            if (!clienteDTO.Valido) return BadRequest("Cliente Inválido");

            Cliente cliente;
            if (clienteDTO.Veiculo is Carro)
            {
                cliente = new Cliente(
                    cpf: clienteDTO.Nome,
                    veiculo: new Carro("01245789"));
            }
            else
            {
                cliente = new Cliente(
                   cpf: clienteDTO.Nome,
                   veiculo: new Moto(clienteDTO.Veiculo.Placa));

            }
            return Ok(_estacionamentoService.AtualizarCliente(idCliente, cliente));
        }

        [HttpDelete, Route("/{idCliente}")]
        public IActionResult ExcluirCliente(Guid idCliente)
        {
            if (_estacionamentoService.RemoverCliente(idCliente))
            {

            }
            

        }

    }
}
