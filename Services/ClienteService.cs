using EstacionamentoApi.Entidades;
using System;
using System.Collections.Generic;

namespace EstacionamentoApi.Services
{
    public class ClienteService
    {
        private EstacionamentoService _Estacionamentoservice;
        private List<Ticket> _ticketsAntigos;

        public void AdicionarTicketAntigo(Guid idCliente)
        {
            var cliente = _Estacionamentoservice.GetCliente(idCliente);
            _ticketsAntigos.Add(cliente.TicketAtual);
            cliente.TicketAtual = new Ticket(cliente);
            _Estacionamentoservice.AtualizarCliente(idCliente, cliente);

        }
        public bool FinalizarPedido(Cliente cli)
        {
            decimal valor = _Estacionamentoservice.CalcularValor(cli.TicketAtual.Id);
            if (cli.TicketAtual.Pago)
            {
                AdicionarTicketAntigo(cli.Id);
                _Estacionamentoservice.RemoverTicket(cli.TicketAtual.Id);
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
