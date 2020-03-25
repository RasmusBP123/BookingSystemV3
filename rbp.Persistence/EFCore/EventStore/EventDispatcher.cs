using rbp.Domain.CalendarContext.Events;
using rbp.Domain.CalendarContext.Interfaces;
using rbp.Persistence.EFCore.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Persistence.EFCore.EventStore
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IMessageBus _messageBus;

        public EventDispatcher(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void Dispatch(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var @event in domainEvents)
            {
                Dispatch(@event);
            }
        }

        private void Dispatch(IDomainEvent @event)
        {
            switch (@event)
            {
                case CalendarInfoChangedEvent calendarInfoEvent:
                    _messageBus.SendCalendarInfoChanged(calendarInfoEvent.Id, calendarInfoEvent.Name);
                    break;

                    //Here goes new domain events
            }
        }
    }
}
