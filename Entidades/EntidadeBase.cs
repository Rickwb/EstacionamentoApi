using System;

namespace EstacionamentoApi.Entidades
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
