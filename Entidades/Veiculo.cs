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

        protected Veiculo(string placa,string marca,string modelo)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
        }

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }


    }
}
