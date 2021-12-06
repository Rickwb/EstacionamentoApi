using System;

namespace EstacionamentoApi.DTOS
{
    public class VeiculoDTO : Validator
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public override void Validar()
        {
            if (string.IsNullOrWhiteSpace(Placa) || Placa.Length != 7)
                throw new Exception("A placa do carro esta em um formato errado");

            Valido = true;
        }
    }
}
