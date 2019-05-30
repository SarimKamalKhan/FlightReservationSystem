using CommonHelper.Constants;
using DataAccess.Repositories.AirLine;
using DataAccess.Repositories.City;
using DataTransferObjects;
using Models.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace BusinessAPI.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
     
        /// <summary>
        /// Get cities by country code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCities/{countryCode}")]
        public HttpResponseMessage GetCities(string countryCode)
        {
            string methodName = "GetCities";
            GetCitiesResponse getCitiesResponse = new GetCitiesResponse();

            try
            {
                string response = string.Empty;
                CityRepository cityRepository = new CityRepository();

                getCitiesResponse.Cities = cityRepository.GetByCountryCode(countryCode, out response);

                ///////////////////Testing
                //CityDTO test = new CityDTO();
                //test.Id = 1;
                //test.Name = "Karachi";
                //test.CityCode = "KAR";

                //getCitiesResponse.Cities.Add(test);

                //test = new CityDTO();
                //test.Id = 2;
                //test.Name = "Lahore";
                //test.CityCode = "LAH";

                //getCitiesResponse.Cities.Add(test);

                response = ResponseCodes.Success;

                /////////////////////

                if (response ==  ResponseCodes.Success)
                   return this.Request.CreateResponse<GetCitiesResponse>(HttpStatusCode.OK, getCitiesResponse);
                else
                    return this.Request.CreateResponse<GetCitiesResponse>(HttpStatusCode.BadRequest, getCitiesResponse);
            }
            catch (Exception ex)
            {
                 return this.Request.CreateResponse<GetCitiesResponse>(HttpStatusCode.InternalServerError, getCitiesResponse);
            }
        }

        

        [HttpGet]
        [Route("GetAirlines/{countryCode}")]
        public HttpResponseMessage GetAirlines(string countryCode)
        {
            string methodName = "GetAirlines";
            GetAirlinesResponse getAirlineResponse = new GetAirlinesResponse();

            try
            {
                string response = string.Empty;
                AirLineRepository airlineRepository = new AirLineRepository();

                //temporary commenting
                getAirlineResponse.AirLines = airlineRepository.GetByCountryCode(countryCode, out response);

                if (response == ResponseCodes.Success)
                    return this.Request.CreateResponse<GetAirlinesResponse>(HttpStatusCode.OK, getAirlineResponse);
                else
                    return this.Request.CreateResponse<GetAirlinesResponse>(HttpStatusCode.BadRequest, getAirlineResponse);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse<GetAirlinesResponse>(HttpStatusCode.InternalServerError, getAirlineResponse);
            }
        }
    }
}
