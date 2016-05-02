using System;
using Windows.UI.Xaml.Data;

namespace Famoser.FrameworkEssentials.UniversalWindows.Converters.Controls
{
    public class RadioConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var p = (string) parameter;
            return value.ToString() == p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return System.Convert.ToBoolean(value) ? parameter : 0;
        }
    }
}
