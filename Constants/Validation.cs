using System;

namespace Constants
{
    public class Validation
    {
        public static string GetEmptyIfNull(object obj)
        {
            if (obj == null)
                return string.Empty;
            else if (obj is DBNull)
                return string.Empty;
            else
                return obj.ToString();
        }

        public static int GetZeroIfNull(object obj)
        {
            if (obj == null)
                return 0;
            else if (obj is DBNull)
                return 0;
            else
                return Convert.ToInt32(obj);
        }

        public static int GetZeroIfEmpty(object obj)
        {
            if (obj.ToString() == string.Empty)
                return 0;
            else if (obj.ToString() == "")
                return 0;
            else
                return Convert.ToInt32(obj);
        }
    }
}
