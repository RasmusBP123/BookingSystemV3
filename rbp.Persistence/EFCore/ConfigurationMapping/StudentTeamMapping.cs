using Domain.Entities.Joint;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace rbp.Persistence.EFCore.ConfigurationMapping
{
    public class StudentTeamMapping : IEntityTypeConfiguration<StudentTeam>
    {
        public void Configure(EntityTypeBuilder<StudentTeam> builder)
        {
            builder.HasKey(st => new { st.StudentId, st.TeamId });
            builder.HasOne(st => st.Student).WithMany(st => st.Teams).HasForeignKey(key => key.StudentId);
            builder.HasOne(st => st.Team).WithMany(st => st.Students).HasForeignKey(key => key.TeamId);
        }
    }
}
