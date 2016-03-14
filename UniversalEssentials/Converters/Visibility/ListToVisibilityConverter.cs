using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace UniversalEssentials.Converters.Visibility
{
    public class ListToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumerable = value as IEnumerable<object>;
            if (enumerable != null && enumerable.Any() && parameter as string != "invert")
                return Windows.UI.Xaml.Visibility.Visible;

            return Windows.UI.Xaml.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
