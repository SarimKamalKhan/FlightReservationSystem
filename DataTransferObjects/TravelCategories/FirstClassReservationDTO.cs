using System;

namespace DataTransferObjects.TravelCategories
{
    public class FirstClassReservationDTO : FlightReservationDTO
    {
        public override int AirLineId { get; set; }
        public override string TravelCategoryCode { get; set; }
        public override int FromCityId { get; set; }
        public override int ToCityId { get; set; }
        public override string ArrivalTime { get; set; }
        public override string DepartureTime { get; set; }

    }
}
