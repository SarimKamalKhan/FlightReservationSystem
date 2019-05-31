namespace Models.Requests
{
    public class FlightReservationRequest
    {
        public string ReservationCode { get; set; }
        public string CNIC { get; set; }
        public string MobileNumber { get; set; }
        /// <summary>
        /// Number of Seats required to be reserved
        /// </summary>
        public int ReservedSeats { get; set; }
        public double TotalAmount { get; set; }

        /// <summary>
        /// This field will be updatd in Reservation Table against the reservation code
        /// UpdatedAvailableSeatsForReservation = CurrentAvailableSeats - ReservedSeats (by customer)
        /// </summary>
        public int UpdatedAvailableSeatsForReservation { get; set; }


    }
}
