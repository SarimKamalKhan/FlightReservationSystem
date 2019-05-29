using System;
using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    public class FirstClassRepository : ITravelCategoryRepository
    {
        public FlightReservationDetailsDTO GetFlightReservationDetails(FirstClassReservationDTO firstClassReservation, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
