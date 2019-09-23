﻿// <auto-generated />
using System;
using AppointmentScheduling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppointmentScheduling.Data.Migrations
{
    [DbContext(typeof(SchedulingContext))]
    partial class SchedulingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppointmentTypeId");

                    b.Property<int>("ClientId");

                    b.Property<DateTime?>("DateTimeConfirmed");

                    b.Property<int?>("DoctorId");

                    b.Property<int>("PatientId");

                    b.Property<int>("RoomId");

                    b.Property<Guid>("ScheduleId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.AppointmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AppointmentTypes");
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.Property<int?>("PreferredDoctorId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicId");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Appointment", b =>
                {
                    b.HasOne("AppointmentScheduling.Core.Model.ScheduleAggregate.Schedule")
                        .WithMany("Appointments")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("FrontDesk.SharedKernel.DateTimeRange", "TimeRange", b1 =>
                        {
                            b1.Property<Guid>("AppointmentId");

                            b1.Property<DateTime>("End")
                                .HasColumnName("End");

                            b1.Property<DateTime>("Start")
                                .HasColumnName("Start");

                            b1.HasKey("AppointmentId");

                            b1.ToTable("Appointments");

                            b1.HasOne("AppointmentScheduling.Core.Model.ScheduleAggregate.Appointment")
                                .WithOne("TimeRange")
                                .HasForeignKey("FrontDesk.SharedKernel.DateTimeRange", "AppointmentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Patient", b =>
                {
                    b.HasOne("AppointmentScheduling.Core.Model.ScheduleAggregate.Client")
                        .WithMany("Patients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("AppointmentScheduling.Core.Model.ValueObjects.AnimalType", "AnimalType", b1 =>
                        {
                            b1.Property<int>("PatientId");

                            b1.Property<string>("Breed");

                            b1.Property<string>("Species");

                            b1.HasKey("PatientId");

                            b1.ToTable("AnimalType");

                            b1.HasOne("AppointmentScheduling.Core.Model.ScheduleAggregate.Patient")
                                .WithOne("AnimalType")
                                .HasForeignKey("AppointmentScheduling.Core.Model.ValueObjects.AnimalType", "PatientId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("AppointmentScheduling.Core.Model.ScheduleAggregate.Schedule", b =>
                {
                    b.OwnsOne("FrontDesk.SharedKernel.DateTimeRange", "DateRange", b1 =>
                        {
                            b1.Property<Guid>("ScheduleId");

                            b1.Property<DateTime>("End")
                                .HasColumnName("End");

                            b1.Property<DateTime>("Start")
                                .HasColumnName("Start");

                            b1.HasKey("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("AppointmentScheduling.Core.Model.ScheduleAggregate.Schedule")
                                .WithOne("DateRange")
                                .HasForeignKey("FrontDesk.SharedKernel.DateTimeRange", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
