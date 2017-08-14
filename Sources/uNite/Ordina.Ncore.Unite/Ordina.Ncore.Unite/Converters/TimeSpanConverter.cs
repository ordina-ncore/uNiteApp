using System;
using System.Globalization;
using Xamarin.Forms;

namespace Ordina.Ncore.Unite.Converters
{
    public class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is TimeSpan ts)
            {
                if(parameter is string part)
                {
                    if (part.Equals("D", StringComparison.CurrentCultureIgnoreCase))
                        return ts.Days;
                    else if (part.Equals("H", StringComparison.CurrentCultureIgnoreCase))
                        return ts.Hours;
                    else if (part.Equals("M", StringComparison.CurrentCultureIgnoreCase))
                        return ts.Minutes;
                    else if (part.Equals("S", StringComparison.CurrentCultureIgnoreCase))
                        return ts.Seconds;
                }
                return $"{ts.Days} Days, {ts.Hours} Hours, {ts.Minutes} Minutes, {ts.Seconds} Seconds";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
