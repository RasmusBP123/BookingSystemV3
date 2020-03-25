using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Timeslot : Entity<Guid>
    {
        public string Description { get; private set; }
        public virtual DateTimeRange Range { get; private set; }
        public virtual List<Booking> Bookings { get; private set; } = new List<Booking>();
        public virtual Calendar Calendar { get; private set; }
        public virtual Teacher Teacher { get; private set; }
        protected Timeslot() { }


        public Timeslot(string description, DateTimeRange range)
        {
            Description = description;
            Range = range;
        }


        public void CreateBooking(Booking booking) => Bookings.Add(booking);

        public bool IsBookingPossible(Booking newBooking)
        {
            if (Bookings.Count == 0) // if list is empty, assume bookings cannot be overlapping
            {
                return true;
            }
            var result = Bookings.All(existingBooking => newBooking.Range.From >= existingBooking.Range.To || newBooking.Range.To <= existingBooking.Range.From);
            return result;
        }

        public bool IsTimeslotsOverlapping(List<Timeslot> timeslotsWhereTeacherIsPresent, Timeslot newTimeslot)
        {
            if (timeslotsWhereTeacherIsPresent.Count == 0)
            {
                return false;
            }

            var result = timeslotsWhereTeacherIsPresent.All(existingTimeslots => newTimeslot.Range.From >= existingTimeslots.Range.To || newTimeslot.Range.To <= existingTimeslots.Range.From);
            return result;
        }
    }
}
