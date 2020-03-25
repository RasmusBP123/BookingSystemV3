using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.CalendarContext.Events
{
    public class CalendarCreatedEvent
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
    }
}
