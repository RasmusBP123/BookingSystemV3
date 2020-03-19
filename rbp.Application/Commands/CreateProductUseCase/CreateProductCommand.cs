using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Application.Commands.CreateProductUseCase
{
    public class CreateProductCommand : IRequest
    {
        public string Name { get; set; }
    }
}
