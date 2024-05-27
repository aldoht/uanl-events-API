using Newtonsoft.Json.Linq;
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
    public class UserController : ApiController
    {
        private readonly userData _userData;

        public UserController()
        {
            _userData = new userData();
        }

        // GET api/<controller>/5
        public User Get(string id)
        {
            return _userData.buscarUsuario(id);
        }

        public void Post([FromBody] User user)
        {
            userData.createUser(user);
        }
    }
}