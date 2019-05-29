using DataAccess.DataBaseComponent;
using System.Configuration;

namespace DataAccess.DatabaseFacade
{
    public class DBComponent
    {
        public static IDBManager IDBMgr()
        {
            IDBManager iDBManager;
            string connectionString = string.Empty;
            {
                connectionString = ConfigurationManager.ConnectionStrings["OraConnection"].ToString();
            }
            iDBManager = new OracleDBManager(connectionString);
           
            return iDBManager;
        }
    }
}
