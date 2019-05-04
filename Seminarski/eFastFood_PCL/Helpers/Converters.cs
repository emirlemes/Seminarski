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
            if (decimal.TryParse(value.Replace('.',','), out number))
                return number;
            else
                return 0;
        }
        public static int ToInt(this string value)
        {
            int number;
            if (int.TryParse(value.Replace('.', ','), out number))
                return number;
            else
                return 0;
        }
    }
}
