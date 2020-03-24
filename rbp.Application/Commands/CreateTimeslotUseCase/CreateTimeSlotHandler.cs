using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateTimeslot
{
    public class CreateTimeSlotHandler : BaseContext, IRequestHandler<CreateTimeslotCommand, bool>
    {
        public CreateTimeSlotHandler(IApplicationDBContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> Handle(CreateTimeslotCommand request, CancellationToken cancellationToken)
        {
            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.Id == request.TeacherId);
            var calendar = _dbContext.Calendars.FirstOrDefault(cal => cal.Id == request.CalendarId);
            var timeslotsWhereTeacherIsPresent = _dbContext.Timeslots.Where(timeslot => timeslot.TeacherId == teacher.Id).ToList();

            var timeSlot = new Timeslot(request.Description, request.From, request.To);

            if (timeSlot.IsTimeslotsOverlapping(timeslotsWhereTeacherIsPresent, timeSlot) == false)
            {
                teacher.CreateTimeSlot(timeSlot);
                await _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
