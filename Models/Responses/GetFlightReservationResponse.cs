using DataTransferObjects.TravelCategories;
using System.Collections.Generic;

namespace Models.Responses
{
    public class GetFlightReservationResponse
    {
        public IList<FlightReservationDetailsDTO> FlightReservationDetails { get; set; }

        public GetFlightReservationResponse()
        {
            FlightReservationDetails = new List<FlightReservationDetailsDTO>();
        }
    }
}
