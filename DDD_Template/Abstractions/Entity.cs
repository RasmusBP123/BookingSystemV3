using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace rbp.Domain.Abstractions
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }
        private List<INotification> _events;
        public Entity()
        {
            _events = new List<INotification>();
        }

        public void Apply(INotification @event)
        {
            _events.Add(@event);
        }

        protected abstract void When(object @event);

        protected abstract void EnsureValidState(object @event);

        public void ClearChanges()
        {
            _events.Clear();
        }

        public List<INotification> GetAllDomainEvents()
        {
            return _events;
        }

        public bool Equals(Entity<TId> other)
        {
            throw new NotImplementedException();
        }
    }
}
