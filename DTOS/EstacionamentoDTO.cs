using System;

namespace EstacionamentoApi.DTOS
{
    public class EstacionamentoDTO : Validator
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public override void Validar()
        {
            if (string.IsNullOrEmpty(CNPJ) || CNPJ.Length != 14) throw new Exception("O CNPJ está incorreto");

            Valido = true;

        }
    }
}
