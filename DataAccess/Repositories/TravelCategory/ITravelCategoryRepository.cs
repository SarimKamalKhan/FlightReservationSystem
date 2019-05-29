using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    interface ITravelCategoryRepository
    {
        /// <summary>
        /// Get Flight reservation details
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        FlightReservationDetailsDTO GetFlightReservationDetails(FirstClassReservationDTO firstClassReservation, out string response);
    }
}
