using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Teacher : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual List<TeacherCalendar> Calendars { get; private set; }
        public virtual List<Timeslot> Timeslots { get; private set; } = new List<Timeslot>();

        public Teacher(string name)
        {
            Name = name;
        }

        public void CreateTimeSlot(Timeslot timeslot)
        {
            this.Timeslots.Add(timeslot);
        }

        public bool IsTimeslotOverlapping(List<TeacherCalendar> teacherCalendars)
        {
            var calendars = teacherCalendars.Select(tc => new Calendar(tc.CalendarId, Timeslots));
            return true;
        }
    }
}
