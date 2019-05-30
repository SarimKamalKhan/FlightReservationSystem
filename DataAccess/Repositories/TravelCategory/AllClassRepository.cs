using System;
using System.Collections.Generic;
using System.Data;
using CommonHelper.Constants;
using Constants;
using DataAccess.DatabaseFacade;
using DataTransferObjects.TravelCategories;

namespace DataAccess.Repositories.TravelCategory
{
    public class AllClassRepository : ITravelCategoryRepository
    {
        private string ClassName = "AllClassRepository";
        public IList<FlightReservationDetailsDTO> GetFlightReservationDetails(dynamic flightReservation, out string response)
        {
            string functionName = ".GetFlightReservationDetails";
            string source = ClassName + functionName;

            response = string.Empty;

            IList<FlightReservationDetailsDTO> flightReservationDetailsDTOs = new List<FlightReservationDetailsDTO>();
            DBManager dbMgr = new DBManager();

            DataSet ds = dbMgr.GetAllClassReservationDetails(flightReservation, out response);

            if (response == ResponseCodes.Success)
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FlightReservationDetailsDTO flightReservationDetails = new FlightReservationDetailsDTO();

                        flightReservationDetails.AirLine = Validation.GetEmptyIfNull(dr["AirLine"]);

                        flightReservationDetails.TravelCategory = Validation.GetEmptyIfNull(dr["TravelCategory"]);

                        flightReservationDetails.FromCity = Validation.GetEmptyIfNull(dr["FromCity"]);

                        flightReservationDetails.ToCity = Validation.GetEmptyIfNull(dr["ToCity"]);

                        flightReservationDetails.ReservationCode = Validation.GetEmptyIfNull(dr["ReservationCode"]);

                        flightReservationDetails.AvailableSeats = Validation.GetZeroIfEmpty(dr["AvailableSeats"]);

                        flightReservationDetails.ArrivalTime = Validation.GetMinDateIfNull(dr["ArrivalTime"]);

                        flightReservationDetails.DepartureTime = Validation.GetMinDateIfNull(dr["DepartureTime"]);

                        flightReservationDetailsDTOs.Add(flightReservationDetails);
                    }
                }
            }

            return flightReservationDetailsDTOs;
        }

    }
}
