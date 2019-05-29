using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    public class EconomyClassRepository : ITravelCategoryRepository
    {
        public FlightReservationDetailsDTO GetFlightReservationDetails(FirstClassReservationDTO firstClassReservation, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
