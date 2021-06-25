using System;
using System.Globalization;
using System.Windows.Data;

namespace Eighth
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not TimeSpan time)
                time = TimeSpan.Zero;
            return time.ToString(@"hh\:mm\:ss\:fff", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(TimeSpan))
                return TimeSpan.TryParse(value?.ToString(), out var time) ? time : TimeSpan.Zero;

            return default;
        }
    }
}
