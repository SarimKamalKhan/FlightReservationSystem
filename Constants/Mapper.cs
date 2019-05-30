using Constants.Constants;
using DataTransferObjects.TravelCategories;
using Models.Requests;
using Models.Responses;

namespace Constants
{
    public static class Mapper
    {
        public static FirstClassReservationDTO GetFirstClassReservationDTO(GetFlightReservationRequest request)
        {
            FirstClassReservationDTO firstClassReservationtRequest = new FirstClassReservationDTO();
            firstClassReservationtRequest.TravelCategoryCode = TravelCategory.FirstClass;
            firstClassReservationtRequest.ToCity = request.ToCity;
            firstClassReservationtRequest.FromCity = request.FromCity;
            firstClassReservationtRequest.ReservationDate = request.ReservationDate;
            firstClassReservationtRequest.AirLineCode = request.AirLineCode;

            return firstClassReservationtRequest;
        }

        public static GetFlightReservationResponse GetFlightReservationResponse(FlightReservationDetailsDTO flightReservationDetailsDTO)
        {
            GetFlightReservationResponse getFlightReservationResponse = new GetFlightReservationResponse();
            getFlightReservationResponse.TravelCategoryCode = flightReservationDetailsDTO.TravelCategoryCode;
            getFlightReservationResponse.ToCity = flightReservationDetailsDTO.ToCity;
            getFlightReservationResponse.FromCity = flightReservationDetailsDTO.FromCity;
            getFlightReservationResponse.ArrivalTime = flightReservationDetailsDTO.ArrivalTime;
            getFlightReservationResponse.DepartureTime = flightReservationDetailsDTO.DepartureTime;

            return getFlightReservationResponse;
        }
    }
}
