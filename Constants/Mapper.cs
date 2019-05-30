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

    }
}
