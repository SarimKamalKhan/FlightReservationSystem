using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class GetFlightReservationRequest
    {
        public int AirLineId { get; set; }
        public string TravelCategoryCode { get; set; }
        public int FromCityId { get; set; }
        public int ToCityId { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
    }
}
