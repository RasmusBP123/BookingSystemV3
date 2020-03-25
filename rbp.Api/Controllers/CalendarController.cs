using Application.UseCases.CreateCalendar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace rbp.WebApi.Controllers
{
    public class CalendarController : ApiBaseController
    {
        public CalendarController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCalendar()
        {
            var calendarCommand = new CreateCalendarCommand("My new Calendar", new Guid("4a8ca1a8-a832-4d69-9ff5-b3549dde0407"));
            await _mediator.Send(calendarCommand);
            return Ok();
        }
    }
}
