using System;
using Windows.UI.Xaml.Data;

namespace UniversalEssentials.Converters.Visibility
{
    public class DateTimeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            if (date == DateTime.MinValue && parameter as string != "invert")
                return Windows.UI.Xaml.Visibility.Collapsed;

            return Windows.UI.Xaml.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
