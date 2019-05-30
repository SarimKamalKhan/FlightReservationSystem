using System;
using System.Collections.Generic;
using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    public class EconomyClassRepository : ITravelCategoryRepository
    {
        public IList<FlightReservationDetailsDTO> GetFlightReservationDetails(dynamic flightReservation, out string response)
        {
            throw new NotImplementedException();
        }

    }
}
