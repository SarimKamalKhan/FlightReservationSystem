using System;

namespace Models.Responses
{
    public class GetFlightReservationResponse
    {
        public string AirLine { get; set; }
        public string TravelCategoryCode { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
        public string UIArrivalTime
        {
            get
            {
                return ArrivalTime.ToString("dd MMM yyyy hh:mm:ss");
            }
        }
        public string UIDepartureTime
        {
            get
            {
                return DepartureTime.ToString("dd MMM yyyy hh:mm:ss");
            }
        }
    }
}
