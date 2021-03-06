﻿using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTimeslot
{
    internal class CreateTimeSlotHandler : BaseContext, IRequestHandler<CreateTimeslotCommand, bool>
    {
        public CreateTimeSlotHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> Handle(CreateTimeslotCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);
            var calendar = await _dbContext.Calendars.FindAsync(request.CalendarId);
            var timeslotsWhereTeacherIsAvailable = _dbContext.Timeslots.Where(timeslot => timeslot.Teacher.Id == teacher.Id).ToList();

            var range = DateTimeRange.Create(request.From, request.To);
            var timeSlot = new Timeslot(request.Description, range.Value);

            if (timeSlot.IsTimeslotsOverlapping(timeslotsWhereTeacherIsAvailable, timeSlot) == false)
            {
                teacher.CreateTimeSlot(timeSlot);
                await _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
