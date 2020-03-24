using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Timeslot : Entity<Guid>
    {
        public string Description { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public virtual List<Booking> Bookings { get; private set; } = new List<Booking>();
        public Guid CalendarId { get; private set; }
        public Guid TeacherId { get; private set; }

        public Timeslot(string description, DateTime from, DateTime to)
        {
            Description = description;
            To = to;
        }

        public void CreateBooking(Booking booking) => Bookings.Add(booking);

        public bool IsBookingPossible(Booking newBooking)
        {
            var result = Bookings.All(existingBooking => newBooking.From >= existingBooking.To || newBooking.To <= existingBooking.From);
            return result;
        }

        public bool IsTimeslotsOverlapping(List<Timeslot> timeslotsWhereTeacherIsPresent, Timeslot newTimeslot)
        {
            var result = timeslotsWhereTeacherIsPresent.All(existingTimeslots => newTimeslot.From >= existingTimeslots.To || newTimeslot.To <= existingTimeslots.From);
            return result;
        }
    }
}
