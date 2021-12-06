using System;

namespace EstacionamentoApi.Entidades
{
    public class Carro : Veiculo, IEntidadeBase
    {
        public Carro(string placa) : base(placa)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; init; }
    }
}
