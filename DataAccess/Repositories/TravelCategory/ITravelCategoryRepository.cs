using DataTransferObjects.TravelCategories;
using System.Collections.Generic;

namespace DataAccess.Repositories.TravelCategory
{
    interface ITravelCategoryRepository
    {
        /// <summary>
        /// Get Flight reservation details
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        IList<FlightReservationDetailsDTO> GetFlightReservationDetails(FirstClassReservationDTO firstClassReservation, out string response);
    }
}
