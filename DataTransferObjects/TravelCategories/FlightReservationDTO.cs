using System;

namespace DataTransferObjects
{
    abstract public class FlightReservationDTO
    {
        public abstract string AirLineCode { get; set; }
        public abstract string TravelCategoryCode { get; set; }
        public abstract string FromCity { get; set; }
        public abstract string ToCity { get; set; }
        public abstract DateTime ReservationDate { get; set; }

    }
}
