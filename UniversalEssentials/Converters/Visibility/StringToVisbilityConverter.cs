using System;
using Windows.UI.Xaml.Data;

namespace UniversalEssentials.Converters.Visibility
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var val = value as string;
            if (!string.IsNullOrEmpty(val) && parameter as string != "invert")
                return Windows.UI.Xaml.Visibility.Collapsed;
            return Windows.UI.Xaml.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
