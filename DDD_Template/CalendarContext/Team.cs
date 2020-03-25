using Domain.Entities.Joint;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Team : Entity<Guid>
    {
        public Name Name { get; private set; }
        public virtual Teacher Teacher { get; private set; }
        public virtual List<StudentTeam> Students { get; private set; } = new List<StudentTeam>();
        public virtual Calendar Calendar { get; private set; }

        public Team(Name name, Teacher teacher) : this()
        {
            Name = name;
            Teacher = teacher;
        }

        private Team()
        {
        }

        public void AttachStudents(IEnumerable<StudentTeam> students)
        {
            Students.AddRange(students);
        }
    }
}
