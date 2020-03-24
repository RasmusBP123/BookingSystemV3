using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandUseCases.AttachTeachersToCalendar
{
    public class AttachTeachersToCalendarCommand : IRequest
    {
        public Guid CalendarId { get; }
        public List<Teacher> Teachers { get; }

        public AttachTeachersToCalendarCommand(Guid calendarId, List<Teacher> teachers)
        {
            CalendarId = calendarId;
            Teachers = teachers;
        }

    }
}
