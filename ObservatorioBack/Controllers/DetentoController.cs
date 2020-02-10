using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ObservatorioBack.Controllers
{
    public class DetentoController : ApiController
    {
        // GET: api/Detento
        public IEnumerable<string> Get()
        {
            return new string[] { "DESI", "UNI7" };
        }

        // GET: api/Detento/5
        public string Get(int id)
        {
            return "consulta " + id;
        }

        // POST: api/Detento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Detento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Detento/5
        public void Delete(int id)
        {
        }
    }
}
