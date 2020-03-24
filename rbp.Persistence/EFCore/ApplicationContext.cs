using Domain.Entities;
using Domain.Entities.Joint;
using Microsoft.EntityFrameworkCore;
using rbp.Domain;
using rbp.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace rbp.Persistence.EFCore
{
    public class ApplicationContext : DbContext, IApplicationDBContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<StudentTeam> StudentTeams { get; set; }
        public DbSet<TeacherCalendar> TeacherCalendars { get; set; }

        public async new Task<bool> SaveChanges()
        {
            return (await base.SaveChangesAsync() > 0);
        }
    }
}
