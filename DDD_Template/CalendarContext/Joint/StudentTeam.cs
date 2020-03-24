using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Joint
{
    public class StudentTeam
    {
        public Guid StudentId { get; private set; }
        public virtual Student Student { get; private set; }
        public Guid TeamId { get; private set; }
        public virtual Team Team { get; private set; }

        public StudentTeam(Guid studentId, Guid teamId)
        {
            StudentId = studentId;
            TeamId = teamId;
        }
    }
}
