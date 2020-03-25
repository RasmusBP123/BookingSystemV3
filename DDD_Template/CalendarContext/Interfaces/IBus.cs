using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.CalendarContext.Interfaces
{
    public interface IBus
    {
        void Send(IEnumerable<object> Message);
    }
}
