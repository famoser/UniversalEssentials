using System;
using Windows.UI.Xaml.Data;

namespace UniversalEssentials.Converters.Visibility
{
    public class BoolToVisbilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boo = (bool)value;
            if (boo && parameter as string != "invert")
                return Windows.UI.Xaml.Visibility.Visible;

            return Windows.UI.Xaml.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
