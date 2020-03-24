using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateTimeslot
{
    public class CreateTimeslotCommand : IRequest<bool>
    {
        public Guid TeacherId { get; set; }
        public Guid CalendarId { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public CreateTimeslotCommand(Guid teacherId, Guid calendarId, string description, DateTime from, DateTime to)
        {
            TeacherId = teacherId;
            CalendarId = calendarId;
            Description = description;
            From = from;
            To = to;
        }
    }
}
