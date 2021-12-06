using System.Collections.Generic;

namespace EstacionamentoApi.Entidades
{
    public abstract class Veiculo
    {
        private List<Veiculo> _veiculos;
        protected Veiculo(string placa)
        {
            
            Placa = placa;
        }

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public IReadOnlyList<Veiculo> Veiculos => _veiculos;

        public Cliente Cliente { get; set; }
    }
}
