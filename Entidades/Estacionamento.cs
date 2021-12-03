using System.Collections.Generic;

namespace EstacionamentoApi.Entidades
{
    public class Estacionamento:EntidadeBase
    {
        public Estacionamento(string nome, string cnpj)
        {
            Nome = nome;
            CNPJ = cnpj;
            _todosTickectsPagos ??= new List<Ticket>();
            _todosTickectsAbertos ??= new List<Ticket>();
            Clientes ??= new List<Cliente>();
        }
        private List<Ticket> _todosTickectsAbertos { get; set; }
        private List<Ticket> _todosTickectsPagos { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public IReadOnlyCollection<Ticket> TodosTicketsAbertos { get => _todosTickectsAbertos; }
        public IReadOnlyCollection<Ticket> TodosTicketsPagos { get => _todosTickectsPagos; }
        public List<Cliente> Clientes { get; set; }
        public int QtdVagasCarro { get; set; }
        public int QtdVagasMoto { get; set; }
    }
}
