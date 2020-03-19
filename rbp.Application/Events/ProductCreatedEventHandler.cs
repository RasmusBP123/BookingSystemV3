using MediatR;
using rbp.Domain.ProductContext.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Application.Events
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {

        public ProductCreatedEventHandler()
        {

        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("did it work");
            return Task.FromResult(true);
        }
    }
}
