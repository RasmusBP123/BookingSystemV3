using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using rbp.Application.Commands.CreateProductUseCase;

namespace rbp.WebApi.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> CreateProduct()
        {
            var productCommand = new CreateProductCommand { Name = "Søm til en fast pris" };
            await _mediator.Send(productCommand);
            return Ok();
        }
    }
}