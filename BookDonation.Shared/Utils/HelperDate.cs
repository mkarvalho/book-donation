using System;
using System.Globalization;

namespace BookDonation.Shared.Utils
{
    public class StringToDate
    {
        
        public static DateTime ConvertToDate(string date)
        {
            var culture = new CultureInfo("pt-BR");
            var newDate = DateTime.Parse(date, culture);
            return DateTime.SpecifyKind(newDate, DateTimeKind.Local);
        }

    }
}
