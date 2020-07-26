using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripLooking.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DomainEvents = new List<IDomainEvent>();
        }

        public Guid Id { get; private set; }

        [NotMapped]
        public IList<IDomainEvent> DomainEvents { get; set; }
    }
}