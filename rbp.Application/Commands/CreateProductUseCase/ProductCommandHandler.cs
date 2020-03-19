using MediatR;
using rbp.Application.Commands.CreateProductUseCase;
using rbp.Domain;
using rbp.Domain.Abstractions;
using rbp.Domain.ProductContext;
using rbp.Domain.ProductContext.Events;
using rbp.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rbp.Application.Commands
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public ProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Name = request.Name,
            };

            product.Apply(new ProductCreatedEvent("Nyt event, bitch"));
            await _repository.Save(product, cancellationToken);
            return Unit.Value;
        }
    }
}
