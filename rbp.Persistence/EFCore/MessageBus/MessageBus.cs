using rbp.Domain.CalendarContext.Interfaces;
using rbp.Persistence.EFCore.Messaging;
using System;
using System.Collections.Generic;

namespace rbp.Persistence.EFCore
{
    public class MessageBus : IMessageBus
    {
        private readonly IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public void SendCalendarInfoChanged(Guid calendarId, string newName)
        {
            //Here should be actual implementation for dispatching a message to external system
            _bus.Send(new List<object> { calendarId, newName });
        }
    }
    public class Bus : IBus
    {
        public void Send(IEnumerable<object> Message)
        {
            Console.WriteLine($"Message Sent :{Message}");
        }
    }
}
