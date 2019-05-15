using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFastFood_PCL.Helpers
{
    public static class Converters
    {
        public static decimal ToDecimal(this string value)
        {
            decimal number;
            if (decimal.TryParse(value, out number))
                return number;
            else
                return 0;
        }
        public static decimal ToDecimal(this object value)
        {
            decimal number;
            if (decimal.TryParse(value.ToString(), out number))
                return number;
            else
                return 0;
        }

        public static int ToInt(this string value)
        {
            int number;
            if (int.TryParse(value, out number))
                return number;
            else
                return 0;
        }

        public static int ToInt(this object value)
        {
            int number;
            if (int.TryParse(value?.ToString(), out number))
                return number;
            else
                return 0;
        }

        public static bool ToBool(this object value)
        {
            bool vrati;
            if (bool.TryParse(value.ToString(), out vrati))
                return vrati;
            else
                return vrati;
        }

    }
}
