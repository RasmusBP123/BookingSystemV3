using MediatR;
using rbp.Application.ViewModels;
using System;

namespace rbp.Application.Queries.GetCalendarUseCase
{
    public class GetCalendarQuery : IRequest<CalendarViewModel>
    {
        public Guid CalendarId { get; set; }

        public GetCalendarQuery(Guid calendarId)
        {
            CalendarId = calendarId;
        }
    }
}
