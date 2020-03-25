using System;

namespace rbp.Application.ViewModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}