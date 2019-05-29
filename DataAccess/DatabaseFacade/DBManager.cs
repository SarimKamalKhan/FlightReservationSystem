using DataAccess.DataBaseComponent;
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

            string SPName = "PKG_CITY.GetByCode";

            GeneralParams[] Params = new GeneralParams[3];

            Params[0] = new GeneralParams("inCode", 100, GeneralParams.GeneralDBTypes.VarChar, countryCode, ParameterDirection.Input);
            Params[1] = new GeneralParams("outCursor", 0, GeneralParams.GeneralDBTypes.Cursor, null, ParameterDirection.Output);
            Params[2] = new GeneralParams("outResponseCode", 4, GeneralParams.GeneralDBTypes.VarChar, null, ParameterDirection.Output);

            //#region File Logging
            //LogManager.GetDBLogger().Info(
            //    new LogMessage().AddSource(source)
            //    .AddUserIdentifier(ActorID)
            //    .AddText("Executing SP", SPName)
            //    );
            //#endregion File Logging

            DataSet ds_Responses = DBComponent.IDBMgr().ExecuteSP(SPName, Params);
            spResponse = Params[3].OutputValue;


            //#region File Logging
            //LogManager.GetDBLogger().Info(
            //    new LogMessage().AddSource(source)
            //    .AddUserIdentifier(ActorID)
            //    .AddText("SP reutrned")
            //    .AddText("Response", spResponse));

            //#endregion File Logging

            return ds_Responses;
        }

    }
}
