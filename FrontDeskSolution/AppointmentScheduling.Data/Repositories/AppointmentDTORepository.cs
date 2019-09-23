using AppointmentScheduling.Core.Interfaces;
using System;
using System.Linq;
using AppointmentScheduling.Core.Model;
using AppointmentScheduling.Core.Model.ScheduleAggregate;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduling.Data.Repositories
{
    public class AppointmentDTORepository : IAppointmentDTORepository
    {
        private readonly SchedulingContext _context;

        public AppointmentDTORepository(SchedulingContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Loads all details of an appointment.
        /// We cannot load the appointment itself from storage as this is called before the appointment is saved.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public AppointmentDTO GetFromAppointment(Appointment appointment)
        {
            string query = $@"select {appointment.Id} 'AppointmentId', 
	                            c.FullName 'ClientName', 
	                            c.EmailAddress 'ClientEmailAddress', 
	                            p.Name 'PatientName', 
	                            d.Name 'DoctorName', 
	                            at.Name 'AppointmentType', 
	                            {appointment.TimeRange.Start} as Start, 
	                            {appointment.TimeRange.End} as 'End'
                            from Clients c
	                            inner join Patients p on p.Id = {appointment.PatientId}
	                            inner join Doctors d on d.Id = {appointment.DoctorId}
	                            inner join AppointmentTypes at on at.Id = {appointment.AppointmentTypeId}
                            where c.id = {appointment.ClientId}";

            // return _context.Appointments.FromSql(query, appointment.Id, appointment.TimeRange.Start, appointment.TimeRange.End, appointment.PatientId, appointment.DoctorId, appointment.AppointmentTypeId, appointment.ClientId).FirstOrDefault();
            return _context.Query<AppointmentDTO>().FromSql(query).FirstOrDefault();
        }
    }
}
