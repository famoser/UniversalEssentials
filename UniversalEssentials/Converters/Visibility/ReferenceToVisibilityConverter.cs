using System;
using UniversalEssentials.Converters.Base;

namespace UniversalEssentials.Converters.Visibility
{
    public class ReferenceToVisibilityConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null != IsInverted(parameter))
                return Windows.UI.Xaml.Visibility.Visible;
            return Windows.UI.Xaml.Visibility.Collapsed;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
