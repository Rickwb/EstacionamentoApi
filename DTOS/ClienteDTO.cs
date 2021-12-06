using EstacionamentoApi.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace EstacionamentoApi.DTOS
{
    public class ClienteDTO : Validator
    {

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Ticket? TicketAtual { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public decimal Multas { get; set; }
        public Veiculo? Veiculo { get; init; }
        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome não completo");
            if (string.IsNullOrEmpty(Cpf))
                throw new Exception("Cpf está vazio");
            if (TicketAtual is null)
                throw new Exception("O tickect deve ser criado");
            if (Veiculo is null)
                throw new Exception("O cliente não possui veiculo");

            Valido = true;
        }
    }
}
