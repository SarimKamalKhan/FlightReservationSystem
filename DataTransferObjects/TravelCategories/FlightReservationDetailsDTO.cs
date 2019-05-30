using System;

namespace DataTransferObjects.TravelCategories
{
    public class FlightReservationDetailsDTO
    {
        public string AirLine { get; set; }
        public string TravelCategoryCode { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
       
    }
}
