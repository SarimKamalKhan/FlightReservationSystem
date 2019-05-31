using CommonHelper.Constants;
using Constants;
using Constants.Constants;
using DataAccess.Repositories.TravelCategory;
using DataTransferObjects;
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
    [RoutePrefix("api/FlightManagement")]
    public class FlightManagementController : ApiController
    {
        [HttpPost]
        [Route("GetFlightSchedules")]
        public HttpResponseMessage GetFlightSchedules(GetFlightSchedulesRequest request)
        {
            string methodName = "GetFlighSchedules";
            GetFlightSchedulesResponse getFlightSchedulesResponse = new GetFlightSchedulesResponse();

            try
            {
                return (GetFlightSchedulesViaCategory(request));

            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse<GetFlightSchedulesResponse>(HttpStatusCode.InternalServerError, getFlightSchedulesResponse);
            }
        }

        [HttpPost]
        [Route("ReserveFlight")]
        public HttpResponseMessage ReserveFlight(FlightReservationRequest request)
        {
            string methodName = "ReserveFlight";
            FlightReservationResponse reserveFlightResponse = new FlightReservationResponse();

            try
            {
                //1. Generate Reservation Number
                string reservationNumber = request.ReservationCode + DateTime.Now.ToString("yyyyMMddHHmmss");

                //2.map request into FlightReservationRequestDTO 

                FlightReservationRequestDTO flightReservationRequestDTO = Mapper.GetReserveFlightRequestDTO(request);

                return this.Request.CreateResponse<FlightReservationResponse>(HttpStatusCode.OK, reserveFlightResponse);

            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse<FlightReservationResponse>(HttpStatusCode.InternalServerError, reserveFlightResponse);
            }
        }

        private HttpResponseMessage GetFlightSchedulesViaCategory(GetFlightSchedulesRequest request)
        {
            GetFlightSchedulesResponse getFlightReservationResponse = new GetFlightSchedulesResponse();
            string response = string.Empty;

            try
            {
                switch (request.TravelCategoryCode)
                {
                    case TravelCategory.FirstClass:

                        #region First Class Reservation

                        //1.map request into FirstClassReservationDTO 
                        FirstClassReservationDTO firstClassReservationtRequest = Mapper.GetFirstClassReservationDTO(request);

                        FirstClassRepository firstClassRepository = new FirstClassRepository();

                        //2.Invoke GetFlightReservationDetails via FirstClassRepository

                        IList<FlightReservationDetailsDTO> flightReservationsDetails = firstClassRepository.GetFlightReservationDetails(firstClassReservationtRequest, out response);

                        //3. set FlightReservationDetails into GetFlightReservationResponse
                        getFlightReservationResponse.FlightReservationDetails = flightReservationsDetails;

                        #endregion

                        break;

                    case TravelCategory.Economy:
                        break;

                    case TravelCategory.Business:
                        break;

                    default:
                        //All categories

                        #region ALl Class Reservation

                        //1.map request into AllClassReservationDTO 
                        AllClassReservationDTO allClassReservationtRequest = Mapper.GetAllClassReservationDTO(request);

                        AllClassRepository allClassRepository = new AllClassRepository();

                        //2.Invoke GetFlightReservationDetails via AllClassRepository

                        IList<FlightReservationDetailsDTO> allClassReservationsDetails = allClassRepository.GetFlightReservationDetails(allClassReservationtRequest, out response);

                        //3. set FlightReservationDetails into GetFlightReservationResponse
                        getFlightReservationResponse.FlightReservationDetails = allClassReservationsDetails;

                        #endregion

                        break;
                }


                if (response == ResponseCodes.Success)
                    return this.Request.CreateResponse<GetFlightSchedulesResponse>(HttpStatusCode.OK, getFlightReservationResponse);
                else
                    return this.Request.CreateResponse<GetFlightSchedulesResponse>(HttpStatusCode.BadRequest, getFlightReservationResponse);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse<GetFlightSchedulesResponse>(HttpStatusCode.InternalServerError, getFlightReservationResponse);
            }
        }

       
    }
}
