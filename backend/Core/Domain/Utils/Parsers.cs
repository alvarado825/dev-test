using System;
using System.Globalization;

namespace Domain.Utils
{
    public static class Parsers
    {
        public static DateTime StringToDateTime(string value)
        {
            value = value.Trim().Replace("-", "").Replace("/", "");
            if (DateTime.TryParseExact(value, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
                return birthDate;

            return DateTime.MinValue;
        }        
    }
}