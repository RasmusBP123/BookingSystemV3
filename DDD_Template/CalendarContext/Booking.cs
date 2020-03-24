using rbp.Domain.Abstractions;
using System;

namespace Domain.Entities
{
    public class Booking : Entity<Guid>
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public virtual Student Student { get; private set; }
        public TimeSpan Duration { get; private set; }


        public Booking(DateTime from, DateTime to) : this()
        {
            From = from;
            To = to;
        }

        private Booking()
        {
        }

        public void GetDurationOfBooking(DateTime from, DateTime to)
        {
            TimeSpan result = to - from;
            Duration = result;
        }
    }
}
