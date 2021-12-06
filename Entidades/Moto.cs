using System;

namespace EstacionamentoApi.Entidades
{
    public class Moto : Veiculo,IEntidadeBase
    {
        public Moto(string placa, string modelo, string marca, Cliente cliente) : base(placa, modelo, marca, cliente)
        {
        }

        public Guid Id { get; init; }
    }
}
