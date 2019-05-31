using DataTransferObjects;

namespace DataAccess.Repositories.FlightReservation
{
    interface IReserveFlightRepository
    {
        FlightReservationResponseDTO ReserveFlight(FlightReservationRequestDTO requestDTO,out string response);
    }
}
