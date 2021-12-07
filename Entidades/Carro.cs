using System;

namespace EstacionamentoApi.Entidades
{
    public class Carro : Veiculo, IEntidadeBase
    {
        public Carro(string placa,string modelo,string marca) : base(placa,modelo,marca)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
    }
}
