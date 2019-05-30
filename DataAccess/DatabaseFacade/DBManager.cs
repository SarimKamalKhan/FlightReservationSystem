﻿using DataAccess.DataBaseComponent;
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
                Params[2] = new GeneralParams("outResponseCode", 2, GeneralParams.GeneralDBTypes.VarChar, null, ParameterDirection.Output);

                ds_Responses = DBComponent.IDBMgr().ExecuteSP(SPName, Params);
                spResponse = Params[3].OutputValue;
            }
            catch (System.Exception ex)
            {
                spResponse = CommonHelper.Constants.ResponseCodes.Failed;
            }

            return ds_Responses;
        }

    }
}
