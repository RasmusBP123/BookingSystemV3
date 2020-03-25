using AutoMapper;
using MediatR;
using rbp.Application.Commands;
using rbp.Application.ViewModels;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Application.Queries.GetCalendarUseCase
{
    public class GetCalendarQueryHandler : BaseContext, IRequestHandler<GetCalendarQuery, CalendarViewModel>
    {
        public GetCalendarQueryHandler(ICalendarContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<CalendarViewModel> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var calendar = await _dbContext.Calendars.FindAsync(request.CalendarId);
            var calendarViewModel = _mapper.Map<CalendarViewModel>(calendar);
            return calendarViewModel;
        }
    }
}
