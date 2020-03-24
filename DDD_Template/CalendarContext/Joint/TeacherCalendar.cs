using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TeacherCalendar
    {
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid CalendarId { get; set; }
        public Calendar Calendar { get; set; }
    }
}
