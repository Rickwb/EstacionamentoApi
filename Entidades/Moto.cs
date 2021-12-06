using System;

namespace EstacionamentoApi.Entidades
{
    public class Moto : Veiculo,IEntidadeBase
    {
        public Moto(string placa) : base(placa)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
    }
}
