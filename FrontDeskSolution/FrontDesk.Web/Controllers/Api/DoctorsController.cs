using System.Net;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientPatientManagement.Core.Interfaces;
using ClientPatientManagement.Core.Model;
using ClientPatientManagement.Data;
using AppointmentScheduling.Data;
using FrontDesk.Web.Models;

namespace FrontDesk.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class DoctorsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private SchedulingContext db;

        public DoctorsController(SchedulingContext db)
        {
            this.db = db;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<DoctorViewModel> Get()
        {
            var allDoctors = db.Doctors.OrderBy(d => d.Name).ToList();
            //allDoctors.Insert(0, DoctorInfo.NoDoctorSelected);
            
            return allDoctors.Select(d => new DoctorViewModel()
            {
                DoctorId = d.Id,
                Name = d.Name
            });

            //return new DoctorViewModel[] {
            //    new DoctorViewModel() {
            //        DoctorId=Guid.Parse("842af74b-c69c-4fbf-a686-74dbbb27c55c"),
            //        Name="Doctor Who"
            //    },
            //    new DoctorViewModel() {
            //        DoctorId=Guid.Parse("821bfa5e-38ce-4217-889a-a2af52dbf65a"),
            //        Name="Doctor McDreamy"
            //    }
            //};
        }

        // GET api/values/5
          [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

          // POST api/values
        [HttpPost]
        public void Post([FromBody]
                         string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]
                        string value)
        {
        }


        // DELETE api/values/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}