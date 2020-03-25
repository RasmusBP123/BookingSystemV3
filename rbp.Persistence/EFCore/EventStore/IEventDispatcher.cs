using rbp.Domain.CalendarContext.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Persistence.EFCore.EventStore
{
    public interface IEventDispatcher
    {
        public void Dispatch(IEnumerable<IDomainEvent> domainEvents);
    }
}
