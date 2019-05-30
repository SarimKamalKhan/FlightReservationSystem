using DataAccess.DataBaseComponent;
using DataTransferObjects.TravelCategories;
using System.Data;

namespace DataAccess.DatabaseFacade
{
    public class DBManager
    {
        private string ClassName = "DBManager";
        public DataSet GetCitiesByCountryCode(string countryCode,out string spResponse)
        {
            string functionName = ".GetCitiesByCode";
            string source = ClassName + functionName;
            spResponse = string.Empty;
            DataSet ds_Responses = new DataSet();
            try
            {

                string SPName = "PKG_CITY.GetByCountryCode";

                GeneralParams[] Params = new GeneralParams[3];

                Params[0] = new GeneralParams("inCode", 100, GeneralParams.GeneralDBTypes.VarChar, countryCode, ParameterDirection.Input);
                Params[1] = new GeneralParams("outCursor", 0, GeneralParams.GeneralDBTypes.Cursor, null, ParameterDirection.Output);
                Params[2] = new GeneralParams("outResponseCode",3, GeneralParams.GeneralDBTypes.VarChar, null, ParameterDirection.Output);

                ds_Responses = DBComponent.IDBMgr().ExecuteSP(SPName, Params);
                spResponse = Params[2].OutputValue;
            }
            catch (System.Exception ex)
            {
                spResponse = CommonHelper.Constants.ResponseCodes.Failed;
            }

            return ds_Responses;
        }

        public DataSet GetFirstClassReservationDetails(FirstClassReservationDTO firstClassReservation, out string spResponse)
        {
            string functionName = ".GetFlightReservationDetails";
            string source = ClassName + functionName;
            spResponse = string.Empty;
            DataSet ds_Responses = new DataSet();
            try
            {

                string SPName = "PKG_FLIGHT_RESERVATION.GetFirstClassDetails";

                GeneralParams[] Params = new GeneralParams[8];

                Params[0] = new GeneralParams("inAirLineCode", 100, GeneralParams.GeneralDBTypes.VarChar, firstClassReservation.AirLineCode, ParameterDirection.Input);

                Params[1] = new GeneralParams("inTravelCategoryCode", 100, GeneralParams.GeneralDBTypes.VarChar, firstClassReservation.TravelCategoryCode, ParameterDirection.Input);

                Params[2] = new GeneralParams("inFromCity", 100, GeneralParams.GeneralDBTypes.VarChar, firstClassReservation.FromCity, ParameterDirection.Input);

                Params[3] = new GeneralParams("inToCity", 100, GeneralParams.GeneralDBTypes.VarChar, firstClassReservation.ToCity, ParameterDirection.Input);

                Params[4] = new GeneralParams("inReservationDate", 100, GeneralParams.GeneralDBTypes.DateTime, firstClassReservation.ReservationDate, ParameterDirection.Input);

                Params[6] = new GeneralParams("outCursor", 0, GeneralParams.GeneralDBTypes.Cursor, null, ParameterDirection.Output);
                Params[7] = new GeneralParams("outResponseCode",3, GeneralParams.GeneralDBTypes.VarChar, null, ParameterDirection.Output);

                ds_Responses = DBComponent.IDBMgr().ExecuteSP(SPName, Params);
                spResponse = Params[7].OutputValue;
            }
            catch (System.Exception ex)
            {
                spResponse = CommonHelper.Constants.ResponseCodes.Failed;
            }

            return ds_Responses;
        }

    }
}
