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
    public class AppointmentTypesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private SchedulingContext db;

        public AppointmentTypesController(SchedulingContext db)
        {
            this.db = db;
        }

         // GET api/values
        [HttpGet]
        public IEnumerable<AppointmentTypeViewModel> Get()
        {
            return db.AppointmentTypes.Select(a => new AppointmentTypeViewModel()
            {
                AppointmentTypeId = a.Id,
                Name=a.Name,
                Code=a.Code,
                Duration=a.Duration
            })
            .OrderBy(a => a.Name);
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