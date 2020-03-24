using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateCalendar
{
    public class CreateCalendarHandler : BaseContext, IRequestHandler<CreateCalendarCommand>
    {
        public CreateCalendarHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);

            var calendar = new Calendar(request.Name);

            var teacherCalendars = new TeacherCalendar( teacher.Id, calendar.Id);

            calendar.AddTeacher(teacherCalendars);
            _dbContext.Calendars.Add(calendar);

            await _dbContext.SaveChanges();

            return Unit.Value;
            
        }
    }
}
