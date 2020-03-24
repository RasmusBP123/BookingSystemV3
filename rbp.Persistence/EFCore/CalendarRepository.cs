using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using rbp.Domain.CalendarContext.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Persistence.EFCore
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly IMediator _mediator;
        private readonly CalendarContext _context;

        public CalendarRepository(IMediator mediator, CalendarContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task DispatchDomainEvents(Calendar entity)
        {
            var events = entity.GetAllDomainEvents();
            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }
        }

        public async Task<Calendar> Get(Guid id, CancellationToken token)
        {
            return await _context.Calendars.FirstOrDefaultAsync(calendar => calendar.Id == id, token);
        }

        public async Task Save(Calendar aggregate, CancellationToken token)
        {
            _context.Calendars.Add(aggregate);

            if (await _context.SaveChangesAsync() > 0)
            {
                await DispatchDomainEvents(aggregate);
            }
        }
    }
}
