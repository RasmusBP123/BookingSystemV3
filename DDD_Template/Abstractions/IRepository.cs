using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Domain.Abstractions
{
    public interface IRepository<TEntity, TKey> where TEntity : AggregateRoot<TKey>
    {
        Task Save(TEntity aggregate, CancellationToken token);
        Task Get(TKey id, CancellationToken token);
        Task DispatchDomainEvents(TEntity entity);
    }
}
