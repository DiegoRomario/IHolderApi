using System;
namespace IHolder.Domain.DomainObjects
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

    }
}
