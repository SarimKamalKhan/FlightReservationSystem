namespace Models.Responses
{
    public class FlightReservationResponse
    {
        public string ReservationNumber { get; set; }
        public int ReserverdSeats { get; set; }

        public double TotalAmount { get; set; }
    }
}
