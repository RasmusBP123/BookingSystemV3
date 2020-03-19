using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.ProductContext.Events
{
    public class ProductCreatedEvent : INotification
    {
        public string Name { get; }
        public ProductCreatedEvent(string name)
        {
            Name = name;
        }

    }
}
