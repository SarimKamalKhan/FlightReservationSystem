using Oracle.ManagedDataAccess.Client;
using System;

namespace FRSApplication
{
    public class DBProvider
    {

        private static OracleConnection DBConnection;

        //****Singleton Class****
        public static OracleConnection GetDBConnection(string connectionString)
        {
            if (DBConnection == null)
            {
                lock (DBConnection)
                {
                    if (DBConnection == null)
                    {
                        DBConnection = new OracleConnection(connectionString);
                    }
                }
            }
            return DBConnection;
        }


    }
}