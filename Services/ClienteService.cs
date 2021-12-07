using EstacionamentoApi.Entidades;
using System;
using System.Collections.Generic;

namespace EstacionamentoApi.Services
{
    public class ClienteService
    {
        private EstacionamentoService _Estacionamentoservice;
        private List<Ticket> _ticketsAntigos;
        public ClienteService(EstacionamentoService estacionamentoService)
        {
            _ticketsAntigos ??= new List<Ticket>();
            _Estacionamentoservice = estacionamentoService;
        }
        public void AdicionarTicketAntigo(Guid idCliente)
        {
            var cliente = _Estacionamentoservice.GetCliente(idCliente);
            _ticketsAntigos.Add(cliente.TicketAtual);
            cliente.TicketAtual = new Ticket(cliente);
            _Estacionamentoservice.AtualizarCliente(idCliente, cliente);

        }
        public bool FinalizarPedido(Cliente cli)
        {
            Guid idTi = cli.TicketAtual.Id;
            _Estacionamentoservice.CalcularTempo(idTi);
            decimal valor = _Estacionamentoservice.CalcularValor(idTi);
            cli.TicketAtual.Pago= cli.Saldo>valor?true:false;
            if (cli.TicketAtual.Pago)
            {
                AdicionarTicketAntigo(cli.Id);
                _Estacionamentoservice.RemoverTicket(idTi);
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
