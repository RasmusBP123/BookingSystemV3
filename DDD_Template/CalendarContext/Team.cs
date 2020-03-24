using Domain.Entities.Joint;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Team : Entity<Guid>
    {
        public string Name { get; private set; }
        public Guid TeacherId { get; private set; }
        public virtual List<StudentTeam> Students { get; private set; } = new List<StudentTeam>();
        public virtual Calendar Calendar { get; private set; }

        public void AttachStudents(IEnumerable<StudentTeam> students)
        {
            Students.AddRange(students);
        }
    }
}
