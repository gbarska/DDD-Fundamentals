using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Enums;
using VetOffice.SharedDatabase.Model;
using VetOffice.SharedDatabase.Model.ValueObjects;

namespace VetOffice.SharedDatabase.DataModel
{
  public class VetOfficeContext : DbContext
  {
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
  
   public VetOfficeContext(DbContextOptions<VetOfficeContext> options) : base(options)
        {
        }
        public VetOfficeContext(){}
     protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {            
              var connString = "Server=localhost;Port=3306;Database=fundamentals;Uid=gbarska;Pwd=password;";
            
              builder
            // .UseLoggerFactory(MyConsoleLoggerFactory)
              .UseMySql(connString)
            .EnableSensitiveDataLogging(true);
    }
  
  }


  
}