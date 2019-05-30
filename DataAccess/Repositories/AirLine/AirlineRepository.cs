using System;
using System.Collections.Generic;
using System.Data;
using CommonHelper;
using CommonHelper.Constants;
using Constants;
using DataAccess.DatabaseFacade;
using DataTransferObjects;

namespace DataAccess.Repositories.AirLine
{

    public class AirLineRepository : IAirlineRepository
    {
        public string ClassName = "AirlineRepository";
        public IList<AirlineDTO> GetByCountryCode(string countryCode, out string response)
        {
            string functionName = ".GetByCountryCode";
            string source = ClassName + functionName;

            response = string.Empty;

            IList<AirlineDTO> airlineList = new List<AirlineDTO>();
            DBManager dbMgr = new DBManager();
            DataSet ds = dbMgr.GetAirlinesByCountryCode(countryCode, out response);

            if (response == ResponseCodes.Success)
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        AirlineDTO airlineDTO = new AirlineDTO();

                        airlineDTO.Name = Validation.GetEmptyIfNull(dr["Name"]);
                        airlineDTO.Id = Validation.GetZeroIfEmpty(dr["ID"]);
                        airlineDTO.CountryCode = Validation.GetEmptyIfNull(dr["CountryCode"]);
                        airlineDTO.Code = Validation.GetEmptyIfNull(dr["CityCode"]);
                        airlineList.Add(airlineDTO);
                    }
                }
            }

            return airlineList;
        }
    }

}
