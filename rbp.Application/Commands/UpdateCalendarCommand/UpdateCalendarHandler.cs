using AutoMapper;
using MediatR;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Application.Commands.UpdateCalendarCommand
{
    public class UpdateCalendarHandler : BaseContext, IRequestHandler<UpdateCalendarCommand>
    {
        public UpdateCalendarHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateCalendarCommand request, CancellationToken cancellationToken)
        {
            var calendar = await _dbContext.Calendars.FindAsync(request.Id);
            var newName = Name.Create(request.Name).Value;
            calendar.EditName(newName);

            await _dbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
