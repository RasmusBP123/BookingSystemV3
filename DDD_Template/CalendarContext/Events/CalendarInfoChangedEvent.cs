using rbp.Domain.CalendarContext.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace rbp.Domain.CalendarContext.Events
{
    public sealed class CalendarInfoChangedEvent : IDomainEvent
    {
        public Guid Id { get; }
        public Name Name { get; }

        public CalendarInfoChangedEvent(Guid id, Name name)
        {
            Id = id;
            Name = name;
        }
    }
}
