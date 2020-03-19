using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.Abstractions
{
    public class AggregateRoot<TId> : Entity<Guid>
    {
        protected override void EnsureValidState(object @event)
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
