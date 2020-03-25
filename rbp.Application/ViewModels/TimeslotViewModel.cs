using System;
using System.Collections.Generic;

namespace rbp.Application.ViewModels
{
    public class TimeslotViewModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}