using System;
using UniversalEssentials.Converters.Base;

namespace UniversalEssentials.Converters.Visibility
{
    public class DateTimeToVisibilityConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            if (date == DateTime.MinValue != IsInverted(parameter))
                return Windows.UI.Xaml.Visibility.Collapsed;

            return Windows.UI.Xaml.Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
