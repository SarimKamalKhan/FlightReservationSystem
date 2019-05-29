using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace BusinessAPI.Controllers
{
    public class HomeController : ApiController
    {
        /// <summary>
        /// Get cities by country code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
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
