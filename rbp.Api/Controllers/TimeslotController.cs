using Application.UseCases.CreateTimeslot;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using rbp.Application.Commands.DeleteTimeslotUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbp.WebApi.Controllers
{
    public class TimeslotController : ApiBaseController
    {
        public TimeslotController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTimeSlot()
        {
            var teacherId = new Guid("4a8ca1a8-a832-4d69-9ff5-b3549dde0407");
            var calendarId = new Guid("0fe38ffc-77df-4cda-823e-08d7d0af9fe2");
            var from = new DateTime(2020, 3, 25, 20, 00, 00);
            var to = new DateTime(2020, 3, 25, 22, 00, 00);
            var description = "Math tutoring";

            var timeslotCommand = new CreateTimeslotCommand(teacherId, calendarId, description, from, to);
            await _mediator.Send(timeslotCommand);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteTimeslot()
        {
            await _mediator.Send(new DeleteTimeslotCommand(new Guid("fc7dbac5-fba5-4ae6-9bbb-08d7d0b1a950")));
            return Ok();
        }
    }
}
