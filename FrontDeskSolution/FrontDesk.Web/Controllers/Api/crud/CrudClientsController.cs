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

namespace FrontDesk.Web.Controllers.Api.Crud
{
    [Route("api/[controller]")]
    public class CrudClientsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRepository<Client> _clientRepository;

        public CrudClientsController(IRepository<Client> clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        // GET api/values
          
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _clientRepository.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            var client = _clientRepository.GetById(id);
            // if(client == null)
            // {
            //     throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            // }
            return client;
        }

        // POST api/values
         [HttpPost]
        public void Post([FromBody]
                         Client client)
        {
            _clientRepository.Insert(client);
        }

        // PUT api/values/5
         [HttpPut("{id}")]
        public void Put(int id, [FromBody]
                        Client client)
        {
            var clientToUpdate = _clientRepository.GetById(id);
            clientToUpdate.FullName = client.FullName;
            clientToUpdate.EmailAddress = client.EmailAddress;
            clientToUpdate.Salutation = client.Salutation;
            clientToUpdate.PreferredName = client.PreferredName;
            clientToUpdate.PreferredDoctorId = client.PreferredDoctorId;
            _clientRepository.Update(clientToUpdate);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }
    }
}