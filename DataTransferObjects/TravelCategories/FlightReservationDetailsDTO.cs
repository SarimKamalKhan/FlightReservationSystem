using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.TravelCategories
{
    public class FlightReservationDetailsDTO
    {
        public int AirLineId { get; set; }
        public string TravelCategoryCode { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
    }
}
