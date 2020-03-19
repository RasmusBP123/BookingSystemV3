using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Domain.ProductContext
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
    }
}
