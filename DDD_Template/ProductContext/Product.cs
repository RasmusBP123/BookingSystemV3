using rbp.Domain.Abstractions;
using rbp.Domain.ProductContext.Events;
using System;

namespace rbp.Domain
{
    public class Product : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public Product CreateProduct(string name)
        {
            var createdProduct = new Product { Name = name };
            Apply(new ProductCreatedEvent(name));
            return createdProduct;
        }

        protected override void EnsureValidState(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
