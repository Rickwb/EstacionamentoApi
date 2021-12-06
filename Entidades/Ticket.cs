using System;

namespace EstacionamentoApi.Entidades
{
    public class Ticket:IEntidadeBase
    {
        public Ticket(Cliente cliente)
        {
            Cliente = cliente;
            HorarioChegada =  DateTime.Now;
            Id = Guid.NewGuid();
        }
        public Cliente Cliente { get; private set; }
        public TimeSpan? TempoTotal { get; set; }
        public DateTime HorarioChegada { get; private set; }
        public DateTime? HorarioSaida { get; set; }
        public decimal TotalPagar { get; set; }
        public bool Pago { get; private set; }
        public int Diaria { get; private set; }
        public bool Lavacao { get; private set; }
        public Guid Id { get; init; }
    }
}
