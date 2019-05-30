using System;

namespace Models.Requests
{
    public class GetFlightSchedulesRequest
    {
        public  string AirLineCode { get; set; }
        public  string TravelCategoryCode { get; set; }
        public  string FromCity { get; set; }
        public  string ToCity { get; set; }
        public  DateTime ReservationDate { get; set; }
    }
}
