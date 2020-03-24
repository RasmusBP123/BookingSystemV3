﻿using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateBooking
{
    internal class CreateBookingHandler : BaseContext, IRequestHandler<CreateBookingCommand, bool>
    {
        public CreateBookingHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var duration = request.To - request.From;
            var booking = new Booking(request.From, request.To);


            var timeslot = _dbContext.Timeslots.Include(t => t.Bookings).FirstOrDefault(timeslot => timeslot.Id == request.TimeslotId);

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