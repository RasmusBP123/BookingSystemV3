using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateBooking
{
    internal class CreateBookingHandler : BaseContext, IRequestHandler<CreateBookingCommand, bool>
    {
        public CreateBookingHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var range = DateTimeRange.Create(request.From, request.To);

            var booking = new Booking(range.Value);
            var timeslot = await _dbContext.Timeslots.FirstAsync(); //I know this is not 'right', but i dont wanna find new ids all the time

            if (timeslot.IsBookingPossible(booking))
            {
                timeslot.CreateBooking(booking);
                await _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
