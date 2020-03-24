using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Joint
{
    public class StudentTeam
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
