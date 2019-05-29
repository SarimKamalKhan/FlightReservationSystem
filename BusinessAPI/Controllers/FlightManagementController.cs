using CommonHelper.Constants;
using Constants;
using Constants.Constants;
using DataAccess.Repositories.TravelCategory;
using DataTransferObjects.TravelCategories;
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
                return (GetFlightReservationDetailsViaCategory(request));

            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse<GetFlightReservationResponse>(HttpStatusCode.InternalServerError, getFlightReservationResponse);
            }
        }

        private HttpResponseMessage GetFlightReservationDetailsViaCategory(GetFlightReservationRequest request)
        {
            GetFlightReservationResponse getFlightReservationResponse = new GetFlightReservationResponse();
            string response = string.Empty;

            try
            {
                switch (request.TravelCategoryCode)
                {
                    case TravelCategory.FirstClass:
                        
                        FirstClassReservationDTO firstClassReservationtRequest = Mapper.GetFirstClassReservationDTO(request);

                        FirstClassRepository firstClassRepository = new FirstClassRepository();

                        FlightReservationDetailsDTO flightReservationDetails = firstClassRepository.GetFlightReservationDetails(firstClassReservationtRequest, out response);


                        break;

                    case TravelCategory.Economy:
                        break;

                    case TravelCategory.Business:
                        break;
                }


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
