using MediatR;
using System.Collections.Generic;

namespace rbp.Domain.Abstractions
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }
       
    }
}
