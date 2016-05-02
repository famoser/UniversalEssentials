using System;
using System.Collections.Generic;
using System.Linq;
using Famoser.FrameworkEssentials.UniversalWindows.Converters.Base;

namespace Famoser.FrameworkEssentials.UniversalWindows.Converters.Visibility
{
    public class ListToVisibilityConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumerable = value as IEnumerable<object>;
            if ((enumerable != null && enumerable.Any()) != IsInverted(parameter))
                return Windows.UI.Xaml.Visibility.Visible;

            return Windows.UI.Xaml.Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
