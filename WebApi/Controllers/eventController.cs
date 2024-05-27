using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class eventController : ApiController
    {
        private readonly userData _userData;

        public eventController()
        {
            _userData = new userData();
        }
        // GET api/<controller>
        public List<Event> Get()
        {
            return _userData.GetEvents();
        }

        // POST api/<controller>
        public void Post([FromBody] Event value)
        {
            userData.createEvent(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Event value)
        {
            value.IdEvento = id;
            _userData.editEvent(value); 
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _userData.deleteEvent(id);
        }
    }
}