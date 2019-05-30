using DataTransferObjects.TravelCategories;
using System.Collections.Generic;

namespace Models.Responses
{
    public class GetFlightSchedulesResponse
    {
        public IList<FlightReservationDetailsDTO> FlightReservationDetails { get; set; }

        public GetFlightSchedulesResponse()
        {
            FlightReservationDetails = new List<FlightReservationDetailsDTO>();
        }
    }
}
