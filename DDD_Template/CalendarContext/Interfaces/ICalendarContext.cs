using Domain.Entities;
using Domain.Entities.Joint;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rbp.Domain.Abstractions
{
    public interface ICalendarContext
    {
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<StudentTeam> StudentTeams { get; set; }
        public DbSet<TeacherCalendar> TeacherCalendars { get; set; }
        public Task<bool> SaveChanges();

    }
}
