using CommonHelper.Constants;
using Models.Requests;
using Models.Responses;
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
        [HttpPost]
        public HttpResponseMessage GetFlightReservationDetails(GetFlightReservationRequest request)
        {
            string methodName = "GetFlightReservationDetails";
            GetFlightReservationResponse getFlightReservationResponse = new GetFlightReservationResponse();

            try
            {
                string response = string.Empty;
                //CityRepository cityRepository = new CityRepository();
                //cities = cityRepository.GetByCountryCode(countryCode, out response);

                if (response == ResponseCodes.Success)
                    return this.Request.CreateResponse<GetFlightReservationResponse>(HttpStatusCode.OK, getFlightReservationResponse);
                else
                    return this.Request.CreateResponse<GetFlightReservationResponse>(HttpStatusCode.BadRequest, getFlightReservationResponse);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse<GetFlightReservationResponse>(HttpStatusCode.InternalServerError, getFlightReservationResponse);
            }
        }
    }
}
