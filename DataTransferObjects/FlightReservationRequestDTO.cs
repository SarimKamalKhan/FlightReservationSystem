using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class FlightReservationRequestDTO
    {
        public string ReservationCode { get; set; }

        public string ReservationNumber { get; set; }
        public string CNIC { get; set; }
        public string MobileNumber { get; set; }
        /// <summary>
        /// Number of Seats required to be resrved
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
