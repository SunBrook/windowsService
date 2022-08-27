using System;

namespace DataDispose.Library.Tools
{
    public class DateTimeConvert
    {
        public static DateTime NumberToDateTime(long number)
        {
            var numberStr = number.ToString();
            var datetimeStr = $"{numberStr.Substring(0, 4)}/{numberStr.Substring(4, 2)}/{numberStr.Substring(6, 2)} {numberStr.Substring(8, 2)}:{numberStr.Substring(10, 2)}:{numberStr.Substring(12, 2)}";
            return Convert.ToDateTime(datetimeStr);
        }
    }
}
