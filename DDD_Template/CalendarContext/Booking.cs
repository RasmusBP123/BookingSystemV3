using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System;

namespace Domain.Entities
{
    public class Booking : Entity<Guid>
    {
        public virtual DateTimeRange Range { get; private set; }
        public virtual Student Student { get; private set; }

        public Booking(DateTimeRange range)
        {
            Range = range;
        }

        protected Booking()
        {
        }

        public TimeSpan GetDurationOfBooking(DateTimeRange range)
        {
            TimeSpan result = range.To - range.From;
            return result;
        }
    }
}
