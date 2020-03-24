using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TeacherCalendar
    {
        public Guid TeacherId { get; private set; }
        public virtual Teacher Teacher { get; private set; }
        public Guid CalendarId { get; private set; }
        public virtual Calendar Calendar { get; private set; }

        public TeacherCalendar(Guid teacherId, Guid calendarId)
        {
            TeacherId = teacherId;
            CalendarId = calendarId;
        }
    }
}
