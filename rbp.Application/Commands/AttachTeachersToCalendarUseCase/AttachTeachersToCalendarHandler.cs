using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandUseCases.AttachTeachersToCalendar
{
    internal class AttachTeachersToCalendarHandler : BaseContext, IRequestHandler<AttachTeachersToCalendarCommand>
    {
        public AttachTeachersToCalendarHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(AttachTeachersToCalendarCommand request, CancellationToken cancellationToken)
        {
            Calendar calendar = await _dbContext.Calendars.FindAsync(request.CalendarId);
            var teacherCalendars = request.Teachers.Select(tc => new TeacherCalendar(tc.Id, calendar.Id));

            calendar.AddTeachers(teacherCalendars);
            await _dbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
