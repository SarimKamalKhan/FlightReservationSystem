namespace Models.Responses
{
    public class ReserveFlightResponse
    {
        public string ReservationNumber { get; set; }
        public int ReserverdSeats { get; set; }

        public double TotalAmount { get; set; }
    }
}
