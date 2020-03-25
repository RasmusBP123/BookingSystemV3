using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application.Commands.UpdateCalendarCommand
{
    public class UpdateCalendarCommand : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }
        public UpdateCalendarCommand(Guid id, string Name)
        {
            Id = id;
            this.Name = Name;
        }
    }
}
