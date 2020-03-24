using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CreateBooking
{
    public class CreateBookingCommand : IRequest<bool>
    {
        public Guid TimeslotId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public CreateBookingCommand(Guid timeslotId, DateTime from, DateTime to)
        {
            TimeslotId = timeslotId;
            From = from;
            To = to;
        }
    }
}
