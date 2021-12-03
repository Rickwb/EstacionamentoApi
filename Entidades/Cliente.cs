using System.Collections.Generic;

namespace EstacionamentoApi.Entidades
{
    public class Cliente:EntidadeBase
    {
        public Cliente(string cpf,Veiculo veiculo)
        {

            TicketAtual = new Ticket();
            Veiculo = veiculo;
            TickekAntigos ??= new List<Ticket>();
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Ticket? TicketAtual { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public List<Ticket> TickekAntigos { get; private set; }
        public decimal Multas { get; set; }
        public Veiculo? Veiculo { get; init; }
    }
}
