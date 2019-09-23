using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using AppointmentScheduling.Core.Model.ScheduleAggregate;
using AppointmentScheduling.Core.Model;

namespace AppointmentScheduling.Data
{
    public class SchedulingContext : DbContext
    {
        public SchedulingContext(DbContextOptions<SchedulingContext> options) : base(options)
        {
        }
        public SchedulingContext(){}
          public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});
      
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbQuery<AppointmentHighlights> Highlights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("Fundamentals_Scheduling");
            modelBuilder.Entity<Client>().HasKey(c => c.Id);

            modelBuilder.Entity<Appointment>().Ignore(a => a.State);
            modelBuilder.Entity<Appointment>().Ignore(a => a.IsPotentiallyConflicting);

            modelBuilder.Entity<Schedule>().Ignore(s => s.DateRange);

            modelBuilder.Entity<Patient>().OwnsOne(s => s.AnimalType).ToTable("AnimalType");

            // modelBuilder.Entity<Appointment>().OwnsOne(s => s.TimeRange).ToTable("DateTimeRange");
            // modelBuilder.Entity<Schedule>().OwnsOne(s => s.DateRange).ToTable("DateTimeRange");
            
            
            modelBuilder.Entity<Appointment>().OwnsOne(s => s.TimeRange).Property(b => b.Start).HasColumnName("Start");
            modelBuilder.Entity<Appointment>().OwnsOne(s => s.TimeRange).Property(b => b.End).HasColumnName("End");
            
            modelBuilder.Entity<Schedule>().OwnsOne(s => s.DateRange).Property(b => b.Start).HasColumnName("Start");
            modelBuilder.Entity<Schedule>().OwnsOne(s => s.DateRange).Property(b => b.End).HasColumnName("End");

            modelBuilder.Query<AppointmentHighlights>().ToView("AppointmentsHighlights");

            // modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {            
                 var connString = "Server=localhost;Port=3306;Database=fundamentals;Uid=gbarska;Pwd=password;";
               
                 builder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                //  .UseMySql(connString)
                .EnableSensitiveDataLogging(true);
            
        }

    }
}