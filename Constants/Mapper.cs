using Constants.Constants;
using DataTransferObjects;
using DataTransferObjects.TravelCategories;
using Models.Requests;
using Models.Responses;

namespace Constants
{
    public static class Mapper
    {
        public static FirstClassReservationDTO GetFirstClassReservationDTO(GetFlightSchedulesRequest request)
        {
            FirstClassReservationDTO firstClassReservationtRequest = new FirstClassReservationDTO();
            firstClassReservationtRequest.TravelCategoryCode = TravelCategory.FirstClass;
            firstClassReservationtRequest.ToCity = request.ToCity;
            firstClassReservationtRequest.FromCity = request.FromCity;
            firstClassReservationtRequest.ReservationDate = request.ReservationDate;
            firstClassReservationtRequest.AirLineCode = request.AirLineCode;

            return firstClassReservationtRequest;
        }

        public static BusinessClassReservationDTO GetBusinessClassReservationDTO(GetFlightSchedulesRequest request)
        {
            BusinessClassReservationDTO businessClassReservationtRequest = new BusinessClassReservationDTO();
            businessClassReservationtRequest.TravelCategoryCode = TravelCategory.Business;
            businessClassReservationtRequest.ToCity = request.ToCity;
            businessClassReservationtRequest.FromCity = request.FromCity;
            businessClassReservationtRequest.ReservationDate = request.ReservationDate;
            businessClassReservationtRequest.AirLineCode = request.AirLineCode;

            return businessClassReservationtRequest;
        }

        public static EconomyClassReservationDTO GetEconomyClassReservationDTO(GetFlightSchedulesRequest request)
        {
            EconomyClassReservationDTO economyClassReservationtRequest = new EconomyClassReservationDTO();
            economyClassReservationtRequest.TravelCategoryCode = TravelCategory.Economy;
            economyClassReservationtRequest.ToCity = request.ToCity;
            economyClassReservationtRequest.FromCity = request.FromCity;
            economyClassReservationtRequest.ReservationDate = request.ReservationDate;
            economyClassReservationtRequest.AirLineCode = request.AirLineCode;

            return economyClassReservationtRequest;
        }

        public static AllClassReservationDTO GetAllClassReservationDTO(GetFlightSchedulesRequest request)
        {
            AllClassReservationDTO allClassReservationtRequest = new AllClassReservationDTO();
            allClassReservationtRequest.TravelCategoryCode = request.TravelCategoryCode;
            allClassReservationtRequest.ToCity = request.ToCity;
            allClassReservationtRequest.FromCity = request.FromCity;
            allClassReservationtRequest.ReservationDate = request.ReservationDate;
            allClassReservationtRequest.AirLineCode = request.AirLineCode;

            return allClassReservationtRequest;
        }

        public static FlightReservationRequestDTO GetReserveFlightRequestDTO(FlightReservationRequest request)
        {
            FlightReservationRequestDTO reservationRequestDTO = new FlightReservationRequestDTO();
            reservationRequestDTO.ReservationCode = request.ReservationCode;
            reservationRequestDTO.CNIC = request.CNIC;
            reservationRequestDTO.MobileNumber = request.MobileNumber;
            reservationRequestDTO.ReservedSeats = request.ReservedSeats;
            reservationRequestDTO.TotalAmount = request.TotalAmount;
            reservationRequestDTO.UpdatedAvailableSeatsForReservation = request.UpdatedAvailableSeatsForReservation;

            return reservationRequestDTO;

        }

        public static FlightReservationResponse GetFlightReservationResponse(FlightReservationResponseDTO reservationResponseDTO)
        {
            FlightReservationResponse flightReservationResponse = new FlightReservationResponse();
            flightReservationResponse.TotalAmount = reservationResponseDTO.TotalAmount;
            flightReservationResponse.ReserverdSeats = reservationResponseDTO.ReserverdSeats;
            flightReservationResponse.ReservationNumber = reservationResponseDTO.ReservationNumber;
            return flightReservationResponse;
        }
    }
}
