using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.TravelCategories
{
    public class BusinessClassReservationDTO : FlightReservationDTO
    {
        public override string AirLineCode { get; set; }
        public override string TravelCategoryCode { get; set; }
        public override string FromCity { get; set; }
        public override string ToCity { get; set; }
        public override DateTime ReservationDate { get; set; }
    }
}

