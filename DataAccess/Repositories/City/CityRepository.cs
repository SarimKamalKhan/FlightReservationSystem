using System;
using System.Collections.Generic;
using System.Data;
using CommonHelper;
using CommonHelper.Constants;
using Constants;
using DataAccess.DatabaseFacade;
using DataTransferObjects;

namespace DataAccess.Repositories.City
{
    public class CityRepository : ICityRepository
    {
        public string ClassName = "CityRepository";
        public IList<CityDTO> GetByCountryCode(string countryCode, out string response)
        {
            string functionName = ".GetByCountryCode";
            string source = ClassName + functionName;

            response = string.Empty;

            IList<CityDTO> cityList = new List<CityDTO>();
            DBManager dbMgr = new DBManager();
            DataSet ds = dbMgr.GetCitiesByCountryCode(countryCode, out response);

            if (response == ResponseCodes.Success)
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        CityDTO cityDTO = new CityDTO();

                        cityDTO.Name = Validation.GetEmptyIfNull(dr["Name"]);
                        cityDTO.Id = Validation.GetZeroIfEmpty(dr["ID"]);
                        cityDTO.CountryCode = Validation.GetEmptyIfNull(dr["CountryCode"]);
                        cityDTO.CityCode = Validation.GetEmptyIfNull(dr["CityCode"]);
                        cityList.Add(cityDTO);
                    }
                }
            }

            return cityList;
        }
    }
}
