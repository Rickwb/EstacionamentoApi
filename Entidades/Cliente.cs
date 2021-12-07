using System;
using System.Collections.Generic;

namespace EstacionamentoApi.Entidades
{
    public class Cliente:IEntidadeBase
    {
      
        public Cliente(string cpf,Veiculo veiculo,Estacionamento estacionamento)
        {
            Id = Guid.NewGuid();
            TicketAtual = new Ticket(this);
            Veiculo = veiculo;
            Estacionamento = estacionamento;   
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Ticket? TicketAtual { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public decimal Multas { get; set; }
        public Veiculo? Veiculo { get; init; }
        public Guid Id { get; init; }

       
    }
}
