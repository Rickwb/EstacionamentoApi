using System;

namespace EstacionamentoApi.Entidades
{
    public class Moto : Veiculo,IEntidadeBase
    {
        public Moto(string placa,string modelo,string marca) : base(placa,modelo,marca)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
    }
}
