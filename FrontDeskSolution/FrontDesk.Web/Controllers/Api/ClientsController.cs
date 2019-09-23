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
    public class ClientsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private SchedulingContext db;

        public ClientsController(SchedulingContext db)
        {
            this.db = db;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ClientViewModel> Get()
        {
            return db.Clients.Select(c => new ClientViewModel()
            {
                ClientId = c.Id,
                FullName = c.FullName,
                Patients = c.Patients.Select(p => new PatientViewModel()
                {
                    Name = p.Name,
                    PatientId = p.Id,
                    PreferredDoctorId=p.PreferredDoctorId.Value
                }).OrderBy(p => p.Name)
            })
            .OrderBy(c => c.FullName);

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