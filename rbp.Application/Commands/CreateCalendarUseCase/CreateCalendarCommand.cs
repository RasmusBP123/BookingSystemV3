using MediatR;
using System;

namespace Application.UseCases.CreateCalendar
{
    public class CreateCalendarCommand : IRequest
    {
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public string Mame { get; }

        public CreateCalendarCommand(string mame)
        {
            Mame = mame;
        }

        public CreateCalendarCommand(string name, Guid teacherId)
        {
            Name = name;
            TeacherId = teacherId;
        }
    }
}
