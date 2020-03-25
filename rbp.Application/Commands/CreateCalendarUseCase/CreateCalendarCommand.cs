using MediatR;
using System;

namespace Application.UseCases.CreateCalendar
{
    public class CreateCalendarCommand : IRequest
    {
        public string Name { get; set; }
        public Guid TeacherId { get; set; }

        public CreateCalendarCommand(string name)
        {
            Name = name;
        }

        public CreateCalendarCommand(string name, Guid teacherId)
        {
            Name = name;
            TeacherId = teacherId;
        }
    }
}
