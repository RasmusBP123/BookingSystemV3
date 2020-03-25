using MediatR;
using rbp.Domain.CalendarContext.Interfaces;
using System;
using System.Collections.Generic;

namespace rbp.Domain.Abstractions
{
    //Started on some event sourcing. Needs to be refactored
    public class AggregateRoot<TId> : Entity<Guid>
    {
        public int Version { get; protected set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public List<IDomainEvent> GetAllDomainEvents()
        {
            return _domainEvents;
        }
    }
}
