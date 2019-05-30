using System;
using System.Collections.Generic;
using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    public class EconomyClassRepository : ITravelCategoryRepository
    {
        IList<FlightReservationDetailsDTO> ITravelCategoryRepository.GetFlightReservationDetails(FirstClassReservationDTO firstClassReservation, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
