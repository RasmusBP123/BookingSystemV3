using Application.UseCases.CreateCalendar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using rbp.Application.Commands.UpdateCalendarCommand;
using rbp.Application.Queries.GetCalendarUseCase;
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCalendarName()
        {
            await _mediator.Send(new UpdateCalendarCommand(new Guid("0fe38ffc-77df-4cda-823e-08d7d0af9fe2"), "My second domain event"));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendar([FromRoute] Guid id)
        {
            var calendar = await _mediator.Send(new GetCalendarQuery(id));
            return Ok(calendar);
        }
    }
}
