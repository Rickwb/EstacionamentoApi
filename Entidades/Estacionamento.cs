using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EstacionamentoApi.Entidades
{
    public class Estacionamento: IEntidadeBase
    {
        public Estacionamento(string nome, string cnpj)
        {
            Id = Guid.NewGuid();
            QtdVagasOcupadasCarro = 0;
            QtdVagasOcupadasMoto = 0;
            Nome = nome;
            CNPJ = cnpj;
        }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public int QtdVagasOcupadasMoto { get; set; }
        public int QtdVagasOcupadasCarro { get; set; }
        public Guid Id { get; init; }
    }
}
