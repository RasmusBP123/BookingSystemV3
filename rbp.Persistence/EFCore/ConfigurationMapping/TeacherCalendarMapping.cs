using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Persistence.EFCore.ConfigurationMapping
{
    public class TeacherCalendarMapping : IEntityTypeConfiguration<TeacherCalendar>
    {
        public void Configure(EntityTypeBuilder<TeacherCalendar> builder)
        {
            builder.HasKey(tc => new { tc.CalendarId, tc.TeacherId });
            builder.HasOne(tc => tc.Calendar).WithMany(tc => tc.Teachers).HasForeignKey(key => key.CalendarId);
            builder.HasOne(tc => tc.Teacher).WithMany(tc => tc.Calendars).HasForeignKey(key => key.TeacherId);
        }
    }
}
