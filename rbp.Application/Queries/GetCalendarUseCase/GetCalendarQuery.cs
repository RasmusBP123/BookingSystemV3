using MediatR;
using rbp.Application.ViewModels;
using System;
using static rbp.Application.Queries.GetCalendarUseCase.GetCalendarQueryHandler;

namespace rbp.Application.Queries.GetCalendarUseCase
{
    public class GetCalendarQuery : IRequest<CalendarSQL>
    {
        public Guid CalendarId { get; set; }

        public GetCalendarQuery(Guid calendarId)
        {
            CalendarId = calendarId;
        }
    }
}
