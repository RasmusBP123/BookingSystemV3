using MediatR;
using System;
using System.Collections.Generic;

namespace rbp.Domain.Abstractions
{
    //Started on some event sourcing. Needs to be refactored
    public class AggregateRoot<TId> : Entity<Guid>
    {
        public int Version { get; protected set; }

        private List<INotification> _events = new List<INotification>();

        public void Apply(INotification @event)
        {
            _events.Add(@event);
        }

        public void ClearChanges()
        {
            _events.Clear();
        }

        public List<INotification> GetAllDomainEvents()
        {
            return _events;
        }
    }
}
