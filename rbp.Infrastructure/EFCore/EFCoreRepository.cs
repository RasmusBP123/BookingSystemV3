using MediatR;
using Microsoft.EntityFrameworkCore;
using rbp.Domain;
using rbp.Domain.Abstractions;
using rbp.Domain.ProductContext;
using rbp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Infrastructure.EFCore
{
    public class EFCoreRepository : IProductRepository
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;

        public EFCoreRepository(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task DispatchDomainEvents(Product entity)
        {
            var events = entity.GetAllDomainEvents();
            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }
        }

        public Task Get(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Product aggregate, CancellationToken token)
        {
            _context.Products.Add(aggregate);

            if(await _context.SaveChangesAsync() > 0)
            {
                await DispatchDomainEvents(aggregate);
            }
        }
    }
}
