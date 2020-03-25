using AutoMapper;
using Domain.Entities;
using MediatR;
using rbp.Application.Commands;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.CreateCalendar
{
    internal class CreateCalendarHandler : BaseContext, IRequestHandler<CreateCalendarCommand>
    {
        public CreateCalendarHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FindAsync(request.TeacherId);

            var name = Name.Create(request.Name);
            var calendar = new Calendar(name.Value);

            var teacherCalendars = new TeacherCalendar(teacher.Id, calendar.Id);

            calendar.AddTeacher(teacherCalendars);
            _dbContext.Calendars.Attach(calendar);

            await _dbContext.SaveChanges();

            return Unit.Value;
            
        }
    }
}
