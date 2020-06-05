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
        public IHttpActionResult Post([FromBody]TesteTO teste)
        {
            return Ok("Oi " + teste.Nome + " " + teste.Num);
        }

        // PUT: api/Detento/5
        public IHttpActionResult Put(int id, [FromBody]TesteTO teste)
        {
            return Ok("Oi " + id + " " + teste.Nome + " " + teste.Num);
        }

        // DELETE: api/Detento/5
        public IHttpActionResult Delete(int id)
        {
            return Ok("Oi " + id);
        }
    }
}
