using rbp.Domain.Abstractions;
using System;

namespace Domain.Entities
{
    public class Booking : Entity<Guid>
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public Guid StudentId { get; private set; }
        public TimeSpan Duration { get; set; }

        public Booking(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public void GetDurationOfBooking(DateTime from, DateTime to)
        {
            TimeSpan result = to - from;
            Duration = result;
        }
    }
}
