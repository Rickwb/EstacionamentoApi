using EstacionamentoApi.Entidades;
using System;

namespace EstacionamentoApi.DTOS
{
    public class TicketDTO:Validator
    {
        public Cliente Cliente { get; private set; }
        public TimeSpan? TempoTotal { get; set; }
        public DateTime HorarioChegada { get; private set; }
        public DateTime? HorarioSaida { get; set; }
        public decimal TotalPagar { get; set; }
        public bool Pago { get; private set; }
        public int Diaria { get; private set; }

        public override void Validar()
        {
            if (Cliente is null) throw new Exception("O ticket não possui nenhum cliente associado a ele");

            if (HorarioChegada == DateTime.MinValue) throw new Exception("O horario de chegada não foi preenchido");

            Valido = true;
            

        }
    }
}
