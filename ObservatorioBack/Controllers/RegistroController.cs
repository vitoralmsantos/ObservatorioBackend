﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ObservatorioBack.Controllers
{
    public class RegistroController : ApiController
    {
        // GET: api/Registro
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Registro/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Registro
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Registro/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registro/5
        public void Delete(int id)
        {
        }
    }
}
