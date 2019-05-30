using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    public class BusinessClassRepository : ITravelCategoryRepository
    {
        public IList<FlightReservationDetailsDTO> GetFlightReservationDetails(dynamic flightReservation, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
