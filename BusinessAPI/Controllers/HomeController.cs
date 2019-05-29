using CommonHelper.Constants;
using DataAccess.Repositories.City;
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
            IList<CityDTO> cities = new List<CityDTO>();
            //TODO : read this article https://stackoverflow.com/questions/400135/listt-or-ilistt
            try
            {
                string response = string.Empty;
                CityRepository cityRepository = new CityRepository();
                cities =   cityRepository.GetByCountryCode(countryCode,out response);

                if(response ==  ResponseCodes.Success)
                   return this.Request.CreateResponse<IList<CityDTO>>(HttpStatusCode.OK, cities);
                else
                    return this.Request.CreateResponse<IList<CityDTO>>(HttpStatusCode.BadRequest, cities);
            }
            catch (Exception ex)
            {
                 return this.Request.CreateResponse<IList<CityDTO>>(HttpStatusCode.InternalServerError, cities);
            }
        }
    }
}
