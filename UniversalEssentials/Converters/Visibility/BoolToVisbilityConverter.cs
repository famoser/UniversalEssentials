using System;
using UniversalEssentials.Converters.Base;

namespace UniversalEssentials.Converters.Visibility
{
    public class BoolToVisbilityConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            var boo = (bool)value;
            if (boo != IsInverted(parameter))
                return Windows.UI.Xaml.Visibility.Visible;

            return Windows.UI.Xaml.Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
