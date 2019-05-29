using Constants.Constants;
using DataTransferObjects.TravelCategories;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
    public static class Mapper
    {
        public static FirstClassReservationDTO GetFirstClassReservationDTO(GetFlightReservationRequest request)
        {
            FirstClassReservationDTO firstClassReservationtRequest = new FirstClassReservationDTO();
            firstClassReservationtRequest.TravelCategoryCode = TravelCategory.FirstClass;
            firstClassReservationtRequest.ToCityId = request.ToCityId;
            firstClassReservationtRequest.FromCityId = request.FromCityId;
            firstClassReservationtRequest.ArrivalTime = request.ArrivalTime;
            firstClassReservationtRequest.DepartureTime = request.DepartureTime;
            firstClassReservationtRequest.AirLineId = request.AirLineId;

            return firstClassReservationtRequest;
        }
    }
}
