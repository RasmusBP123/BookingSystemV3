using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.Abstractions
{
    public class BaseDomainEvent
    {
        public int Version { get; set; }
    }
}
