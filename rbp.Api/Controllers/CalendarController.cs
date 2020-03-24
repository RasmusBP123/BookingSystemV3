using Application.UseCases.CreateCalendar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbp.WebApi.Controllers
{
    public class CalendarController : CustomBaseController
    {
        public CalendarController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalendar()
        {
            await _mediator.Send(new CreateCalendarCommand("My new Calendar"));
            return Ok();
        }
    }
}
