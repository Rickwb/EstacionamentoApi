using EstacionamentoApi.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using EstacionamentoApi.DTOS;
using System.Collections.Generic;

namespace EstacionamentoApi.DTOS
{
    public class ClienteDTO : Validator
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Multas { get; private set; }
        public CarroDTO Carro { get; set; }
        public MotoDTO? Moto { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome não completo");
            if (string.IsNullOrEmpty(Cpf))
                throw new Exception("Cpf está vazio");
            if (Carro is null && Moto is null)
                throw new Exception("O cliente não possui veiculo");

            Valido = true;
        }
    }
}
