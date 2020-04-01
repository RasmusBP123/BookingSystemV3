using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ApiBaseController : Controller
    {
        protected readonly IMediator _mediator;

        protected ApiBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected new IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }
    }
}
