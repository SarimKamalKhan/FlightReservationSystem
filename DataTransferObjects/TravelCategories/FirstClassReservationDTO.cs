using System;

namespace DataTransferObjects.TravelCategories
{
    public class FirstClassReservationDTO : FlightReservationDTO
    {
        public override string AirLineCode {get; set;}
        public override string TravelCategoryCode {get; set;}
        public override string FromCity {get; set;}
        public override string ToCity {get; set;}
        public override DateTime ReservationDate {get; set;}
    }
}
