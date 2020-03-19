using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.ProductContext.Events
{
    public class BaseProductEvent : BaseDomainEvent
    {
        public Guid Id { get; set; }
    }
}
