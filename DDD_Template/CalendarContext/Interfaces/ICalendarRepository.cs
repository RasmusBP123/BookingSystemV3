using Domain.Entities;
using rbp.Domain.Abstractions;
using System;

namespace rbp.Domain.CalendarContext.Interfaces
{
    public interface ICalendarRepository : IRepository<Calendar, Guid>
    {
    }
}
