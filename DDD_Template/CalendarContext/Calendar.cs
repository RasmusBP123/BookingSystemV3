using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using rbp.Domain.CalendarContext.Events;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Calendar : AggregateRoot<Guid>
    {
        public Name Name { get; private set; }
        public virtual List<TeacherCalendar> Teachers { get; private set; } = new List<TeacherCalendar>();
        public virtual List<Timeslot> Timeslots { get; private set; } = new List<Timeslot>();
        public virtual List<Team> Teams { get; private set; } = new List<Team>();

        public Calendar(Name name)
        {
            Name = name;
        }

        private Calendar() { }

        public Calendar(Guid id, List<Timeslot> timeslots)
        {
            Id = id;
            Timeslots = timeslots;
        }

        public void AddTeacher(TeacherCalendar teacher)
        {
            Teachers.Add(teacher);
        }

        public void AddTeachers(IEnumerable<TeacherCalendar> teachers)
        {
            Teachers.AddRange(teachers);
        }

        public void EditName(Name name)
        {
            if (Name != name)
            {
                RaiseDomainEvent(new CalendarInfoChangedEvent(Id, name));
            }

            Name = name;
        }
    }
}
