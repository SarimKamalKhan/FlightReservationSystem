using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusinessAPI.Controllers
{
    public class FlightManagementController : ApiController
    {
        // GET: api/FlightManagement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlightManagement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FlightManagement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FlightManagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FlightManagement/5
        public void Delete(int id)
        {
        }
    }
}
