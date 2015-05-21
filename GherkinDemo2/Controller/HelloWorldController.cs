using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GherkinDemo2.Controller
{
    public class HelloWorldController : ApiController
    {
        // GET: api/HelloWorld
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HelloWorld/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HelloWorld
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/HelloWorld/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HelloWorld/5
        public void Delete(int id)
        {
        }
    }
}
