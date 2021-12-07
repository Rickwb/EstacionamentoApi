using EstacionamentoApi.DTOS;
using EstacionamentoApi.Entidades;
using EstacionamentoApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EstacionamentoApi.Controllers
{
    [ApiController, Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private EstacionamentoService _estacionamentoService;
        private ClienteService _clienteService;
        public EstacionamentoController(EstacionamentoService estacionamentoService, ClienteService clienteService)
        {
            _estacionamentoService = estacionamentoService;
            _clienteService = clienteService;
        }
        [HttpPost,Route("/AdicionarCliente")]
        public IActionResult CadastraCliente(ClienteDTO clienteDTO)
        {
            clienteDTO.Validar();
            if (!clienteDTO.Valido)
                return BadRequest("Cliente Invalido");
            Cliente cliente;
            if (clienteDTO.Moto is null)
            {
                cliente = new Cliente(
                    cpf: clienteDTO.Cpf,
                    nome: clienteDTO.Nome,
                    veiculo: new Carro(clienteDTO.Carro.Placa)
                    );
            }
            else
            {
                cliente = new Cliente(
                   cpf: clienteDTO.Cpf,
                   nome: clienteDTO.Nome,
                   veiculo: new Moto(clienteDTO.Moto.Placa)
                   );

            }

            var cliReturn=_estacionamentoService.CadastrarCliente(cliente);
            if (cliReturn != null) return Created("", cliReturn);
            
            return BadRequest();
        }
        [HttpGet]
        public IActionResult BuscarTodosClientes()
        {
            return Ok(_estacionamentoService.GetAllClientes());
        }

        [HttpGet, Route("/{idCliente}")]
        public IActionResult BuscarClienteId(Guid idCliente)
        {
            return Ok(_estacionamentoService.GetCliente(idCliente));
        }

        [HttpPut, Route("/{idCliente}")]
        public IActionResult AtualizarCliente(Guid idCliente, ClienteDTO clienteDTO)
        {
            clienteDTO.Validar();
            if (!clienteDTO.Valido) return BadRequest("Cliente Inválido");

            Cliente cliente;
            if (clienteDTO.Moto is null)
            {
                cliente = new Cliente(
                    cpf: clienteDTO.Cpf,
                    nome: clienteDTO.Nome,
                    veiculo: new Carro(clienteDTO.Carro.Placa)
                    );
                    
            }
            else
            {
                cliente = new Cliente(
                   cpf: clienteDTO.Cpf,
                   nome: clienteDTO.Nome,
                   veiculo: new Moto(clienteDTO.Moto.Placa)
                   );

            }
            return Ok(_estacionamentoService.AtualizarCliente(idCliente, cliente));
        }

        [HttpDelete, Route("/{idCliente}")]
        public IActionResult ExcluirCliente(Guid idCliente)
        {
            if (_estacionamentoService.RemoverCliente(idCliente))
            {
                return NoContent();
            }
            return BadRequest("Não foi possivel excluit os cliente");
          
            

        }

    }
}
