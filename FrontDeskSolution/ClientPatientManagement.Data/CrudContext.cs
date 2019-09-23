using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ClientPatientManagement.Core.Model;
using FrontDesk.SharedKernel.Enums;

namespace ClientPatientManagement.Data
{
    public class CrudContext : DbContext
    {
      public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
        }
        public CrudContext(){}
          public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});
      
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
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

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Add Doctors
            var drSmith = new Doctor { Id = 1, Name = "Dr. Smith" };
            var drWho = new Doctor { Id = 2, Name = "Dr. Who" };
            var drMcDreamy = new Doctor { Id = 3, Name = "Dr. McDreamy" };
            
            modelBuilder.Entity<Doctor>().HasData(
              drSmith, drWho, drMcDreamy 
            );

            //add client
            var clientSteve = new Client
            {   Id = 1,
                FullName = "Steve Smith",
                PreferredName = "Steve",
                Salutation = "Mr.",
                
                PreferredDoctorId = drSmith.Id
            };

            //add patient
            var patient = new Patient(clientSteve) {Id = 1, Gender = Gender.Male, Name = "Darwin", ClientId = 1};
            // clientSteve.Patients = new List<Patient>();
            // clientSteve.Patients.Add(patient);

            modelBuilder.Entity<Client>().HasData(
                clientSteve
            );

            modelBuilder.Entity<Patient>().HasData(new
                    {
                        Id = 1,
                        ClientId = 1, // Just Works Now
                        Gender = Gender.Male,
                         Name = "Darwin"
                    }
            );
            
            // add Rooms
            // for (int i = 0; i < 5; i++)
            // {
                var room = new Room { Id = 1, Name = string.Format("Exam Room {0}", 1) };
                 modelBuilder.Entity<Room>().HasData(
                room
            );

            // }
        }
    }

    // public class TestInitializerForCrudContext : DropCreateDatabaseAlways<CrudContext>
    // {
    //     protected override void Seed(CrudContext context)
    //     {
    //         base.Seed(context);

    //         // Add Doctors
    //         var drSmith = new Doctor { Name = "Dr. Smith" };
    //         var drWho = new Doctor { Name = "Dr. Who" };
    //         var drMcDreamy = new Doctor { Name = "Dr. McDreamy" };
    //         context.Doctors.Add(drSmith);
    //         context.Doctors.Add(drWho);
    //         context.Doctors.Add(drMcDreamy);

    //         var clientSteve = new Client
    //         {
    //             FullName = "Steve Smith",
    //             PreferredName = "Steve",
    //             Salutation = "Mr.",
    //             PreferredDoctorId = drSmith.Id
    //         };
    //         context.Clients.Add(clientSteve);
    //         context.Patients.Add(new Patient(clientSteve) {Gender = Gender.Male, Name = "Darwin"});
    //         context.Patients.Add(new Patient(clientSteve)
    //         {
    //             Gender = Gender.Female,
    //             Name = "Rumor",
    //             PreferredDoctorId = drWho.Id
    //         });

    //         var clientJulie = new Client
    //         {
    //             FullName = "Julia Lerman",
    //             PreferredName = "Julie",
    //             Salutation = "Mrs.",
    //             PreferredDoctorId = drMcDreamy.Id
    //         };
    //         context.Clients.Add(clientJulie);
    //         context.Patients.Add(new Patient(clientJulie) {Gender = Gender.Male, Name = "Sampson"});

    //         // add Rooms
    //         for (int i = 0; i < 5; i++)
    //         {
    //             var room = new Room { Name = string.Format("Exam Room {0}", i+1) };
    //             context.Rooms.Add(room);
    //         }
        // }
    // }
}