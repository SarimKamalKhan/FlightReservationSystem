using DTOLibrary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace BusinessAPI.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetCities(string countryCode)
        {
            string methodName = "GetCities";
            List<City> cities = new List<City>();

            try
            {
                return this.Request.CreateResponse<List<City>>(HttpStatusCode.OK, cities);
            }
            catch (Exception ex)
            {
                 return this.Request.CreateResponse<List<City>>(HttpStatusCode.InternalServerError, cities);
            }
        }
    }
}
