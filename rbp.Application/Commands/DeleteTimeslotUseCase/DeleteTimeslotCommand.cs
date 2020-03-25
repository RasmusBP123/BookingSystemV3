using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application.Commands.DeleteTimeslotUseCase
{
    public class DeleteTimeslotCommand : IRequest
    {
        public Guid TimeslotId { get; set; }

        public DeleteTimeslotCommand(Guid timeslotId)
        {
            TimeslotId = timeslotId;
        }
    }
}
