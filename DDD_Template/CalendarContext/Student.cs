using Domain.Entities.Joint;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Student : Entity<Guid>
    {
        public string Name { get; private set; }
        public virtual List<StudentTeam> Teams { get; private set; }
        public virtual List<Booking> Bookings { get; private set; }

        public bool IsBookingLimitReached()
        {
            var result = Bookings.Where(b => b.To > DateTime.Now).Count() >= 2;
            return result;
        }
    }
}
