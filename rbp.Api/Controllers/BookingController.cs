using Application.UseCases.CreateBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rbp.WebApi.Controllers
{
    public class BookingController : ApiBaseController
    {
        public BookingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBooking()
        {
            var timeslotId = new Guid("fc7dbac5-fba5-4ae6-9bbb-08d7d0b1a950");
            var from = new DateTime(2020, 3, 25, 20, 00, 00);
            var to = new DateTime(2020, 3, 25, 22, 00, 00);

            var bookingCommand = new CreateBookingCommand(timeslotId, from, to);
            await _mediator.Send(bookingCommand);
            return Ok();
        }
    }
}
