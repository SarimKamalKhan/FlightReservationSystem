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

        public static AllClassReservationDTO GetAllClassReservationDTO(GetFlightReservationRequest request)
        {
            AllClassReservationDTO allClassReservationtRequest = new AllClassReservationDTO();
            allClassReservationtRequest.TravelCategoryCode = request.TravelCategoryCode;
            allClassReservationtRequest.ToCity = request.ToCity;
            allClassReservationtRequest.FromCity = request.FromCity;
            allClassReservationtRequest.ReservationDate = request.ReservationDate;
            allClassReservationtRequest.AirLineCode = request.AirLineCode;

            return allClassReservationtRequest;
        }

    }
}
