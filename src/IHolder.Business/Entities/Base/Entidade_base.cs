using System;
namespace IHolder.Business.Entities.Base
{
    public abstract class Entidade_base
    {
        public Entidade_base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

    }
}
