using DataTransferObjects.TravelCategories;

namespace DataTransferObjects
{
    abstract public class FlightReservationDTO
    {
        public abstract int AirLineId { get; set; }
        public abstract string TravelCategoryCode { get; set; }
        public abstract int FromCityId { get; set; }
        public abstract int ToCityId { get; set; }
        public abstract string ArrivalTime { get; set; }
        public abstract string DepartureTime { get; set; }
     
       
    }
}
