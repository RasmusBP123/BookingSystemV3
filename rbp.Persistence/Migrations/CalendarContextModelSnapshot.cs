﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rbp.Persistence.EFCore;

namespace rbp.Persistence.Migrations
{
    [DbContext(typeof(CalendarContext))]
    partial class CalendarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeslotId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TimeslotId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Domain.Entities.Calendar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("Domain.Entities.Joint.StudentTeam", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("StudentTeams");
                });

            modelBuilder.Entity("Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Domain.Entities.TeacherCalendar", b =>
                {
                    b.Property<Guid>("CalendarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CalendarId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCalendars");
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CalendarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Domain.Entities.Timeslot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CalendarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Timeslots");
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany("Bookings")
                        .HasForeignKey("StudentId");

                    b.HasOne("Domain.Entities.Timeslot", null)
                        .WithMany("Bookings")
                        .HasForeignKey("TimeslotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("rbp.Domain.CalendarContext.DateTimeRange", "Range", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("From")
                                .HasColumnName("From")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("To")
                                .HasColumnName("To")
                                .HasColumnType("datetime2");

                            b1.HasKey("BookingId");

                            b1.ToTable("Bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });
                });

            modelBuilder.Entity("Domain.Entities.Joint.StudentTeam", b =>
                {
                    b.HasOne("Domain.Entities.Student", "Student")
                        .WithMany("Teams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Team", "Team")
                        .WithMany("Students")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.TeacherCalendar", b =>
                {
                    b.HasOne("Domain.Entities.Calendar", "Calendar")
                        .WithMany("Teachers")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Teacher", "Teacher")
                        .WithMany("Calendars")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Team", b =>
                {
                    b.HasOne("Domain.Entities.Calendar", "Calendar")
                        .WithMany("Teams")
                        .HasForeignKey("CalendarId");

                    b.HasOne("Domain.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Domain.Entities.Timeslot", b =>
                {
                    b.HasOne("Domain.Entities.Calendar", "Calendar")
                        .WithMany("Timeslots")
                        .HasForeignKey("CalendarId");

                    b.HasOne("Domain.Entities.Teacher", "Teacher")
                        .WithMany("Timeslots")
                        .HasForeignKey("TeacherId");

                    b.OwnsOne("rbp.Domain.CalendarContext.DateTimeRange", "Range", b1 =>
                        {
                            b1.Property<Guid>("TimeslotId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("From")
                                .HasColumnName("From")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("To")
                                .HasColumnName("To")
                                .HasColumnType("datetime2");

                            b1.HasKey("TimeslotId");

                            b1.ToTable("Timeslots");

                            b1.WithOwner()
                                .HasForeignKey("TimeslotId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
