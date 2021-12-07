using System;
using System.Collections.Generic;

namespace EstacionamentoApi.Entidades
{
    public class Cliente:IEntidadeBase
    {
      
        public Cliente(string cpf,string nome,Veiculo veiculo)
        {
            Id = Guid.NewGuid();
            Cpf = cpf;
            Nome = nome;
            TicketAtual = new Ticket(this);
            Veiculo = veiculo;
            var rdn= new Random();
            Saldo = (decimal)rdn.NextDouble()*rdn.Next(0,100);
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Ticket? TicketAtual { get; set; }
        public decimal Saldo { get; init; }
        public decimal Multas { get; set; }
        public Veiculo? Veiculo { get; init; }
        public Guid Id { get; init; }

       
    }
}
