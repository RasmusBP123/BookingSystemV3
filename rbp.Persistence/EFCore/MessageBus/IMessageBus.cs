using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Persistence.EFCore.Messaging
{ 
    public interface IMessageBus
    {
        public void SendCalendarInfoChanged(Guid calendarId, string newName);
    }
}
