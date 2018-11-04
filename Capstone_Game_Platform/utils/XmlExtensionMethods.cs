using System;
using System.Xml.Linq;

namespace Capstone_Game_Platform
{
    static class XmlExtensionMethods
    {
        #region GetAsString Method
        public static string GetAsString(this XAttribute attr)
        {
            string ret = string.Empty;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                ret = attr.Value;
            }

            return ret;
        }
        #endregion

        #region GetAsInteger Method
        public static int GetAsInteger(this XAttribute attr)
        {
            int ret = 0;
            int value = 0;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (int.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsLong Method
        public static long GetAsLong(this XAttribute attr)
        {
            long ret = 0;
            long value = 0;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (long.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsDouble Method
        public static double GetAsDouble(this XAttribute attr)
        {
            double ret = 0;
            double value = 0;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (double.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsFloat Method
        public static float GetAsFloat(this XAttribute attr)
        {
            float ret = 0;
            float value = 0;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (float.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsShort Method
        public static short GetAsShort(this XAttribute attr)
        {
            short ret = 0;
            short value = 0;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (short.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsDecimal Method
        public static decimal GetAsDecimal(this XAttribute attr)
        {
            decimal ret = 0;
            decimal value = 0;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (decimal.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsDateTime Method
        public static DateTime GetAsDateTime(this XAttribute attr)
        {
            DateTime ret = default(DateTime);
            DateTime value = default(DateTime);

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (DateTime.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion

        #region GetAsBoolean Method
        public static bool GetAsBoolean(this XAttribute attr)
        {
            bool ret = false;
            bool value = false;

            if (attr != null && !string.IsNullOrEmpty(attr.Value))
            {
                if (bool.TryParse(attr.Value, out value))
                    ret = value;
            }

            return ret;
        }
        #endregion
    }
}
