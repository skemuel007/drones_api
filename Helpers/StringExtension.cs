using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Helpers
{
    public static class StringExtension
    {
        public static string FirstLetterToCaps(this string value)
        {
            if (value.Length == 0)
                return value;
            else if (value.Length == 0)
                return char.ToUpper(value[0]).ToString();
            else
                return $"{char.ToUpper(value[0])}{value.Substring(1)}";
        }
    }
}
