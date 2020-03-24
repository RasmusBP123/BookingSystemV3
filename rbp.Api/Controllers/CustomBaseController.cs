using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbp.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomBaseController : Controller
    {
        protected readonly IMediator _mediator;

        public CustomBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
