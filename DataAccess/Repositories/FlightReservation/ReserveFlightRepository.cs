using System;
using CommonHelper.Constants;
using DataAccess.DatabaseFacade;
using DataTransferObjects;

namespace DataAccess.Repositories.FlightReservation
{
    public class ReserveFlightRepository : IReserveFlightRepository
    {
        private string ClassName = "ReserveFlightRepository";
        public FlightReservationResponseDTO ReserveFlight(FlightReservationRequestDTO requestDTO, out string response)
        {
            string functionName = ".ReserveFlight";
            string source = ClassName + functionName;

            response = string.Empty;

            FlightReservationResponseDTO flightReservationResponseDTO = new FlightReservationResponseDTO();
            DBManager dbMgr = new DBManager();

            //1.Insert customer Reserve Flight details
            //2.If successfully  then update available seats on reserve flight table and commit
            //3.otherwise rollback

            int rowsEffected = dbMgr.ReserveFlight(requestDTO, out response);

            if (response == ResponseCodes.Success)
            {
                flightReservationResponseDTO.ReservationNumber = requestDTO.ReservationNumber;
                flightReservationResponseDTO.ReserverdSeats = requestDTO.ReservedSeats;
                flightReservationResponseDTO.TotalAmount = requestDTO.TotalAmount;
            }

            return flightReservationResponseDTO;
        }
    }
}
