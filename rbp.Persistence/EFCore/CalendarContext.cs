using Domain.Entities;
using Domain.Entities.Joint;
using Microsoft.EntityFrameworkCore;
using rbp.Domain.Abstractions;
using rbp.Domain.CalendarContext;
using rbp.Domain.CalendarContext.Events;
using rbp.Persistence.EFCore.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace rbp.Persistence.EFCore
{
    public class CalendarContext : DbContext, ICalendarContext
    {
        private readonly IEventDispatcher _eventDispatcher;

        public CalendarContext(DbContextOptions options, IEventDispatcher eventDispatcher) : base(options)
        {
            _eventDispatcher = eventDispatcher;
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
            List<AggregateRoot<Guid>> entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is AggregateRoot<Guid>)
                .Select(x => (AggregateRoot<Guid>)x.Entity).ToList();

            var result = await base.SaveChangesAsync() > 0;

            foreach (var entity in entities)
            {
                _eventDispatcher.Dispatch(entity.DomainEvents);
                entity.ClearDomainEvents();
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Calendar>(x =>
            {
                x.Property(p => p.Name).HasConversion(p => p.Value, p => Name.Create(p).Value);
            });

            modelBuilder.Entity<Student>(x =>
            {
                x.Property(p => p.Name).HasConversion(p => p.Value, p => Name.Create(p).Value);
            });

            modelBuilder.Entity<Team>(x =>
            {
                x.Property(p => p.Name).HasConversion(p => p.Value, p => Name.Create(p).Value);
            });

            modelBuilder.Entity<Teacher>(x =>
            {
                x.Property(p => p.Name).HasConversion(p => p.Value, p => Name.Create(p).Value);
            });

            modelBuilder.Entity<Timeslot>(x =>
            {
                x.OwnsOne(p => p.Range, p =>
                {
                    p.Property(pp => pp.From).HasColumnName("From");
                    p.Property(pp => pp.To).HasColumnName("To");
                });
                x.HasMany(p => p.Bookings).WithOne().OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Booking>(x =>
            {
                x.OwnsOne(p => p.Range, p =>
                {
                    p.Property(pp => pp.From).HasColumnName("From");
                    p.Property(pp => pp.To).HasColumnName("To");
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
