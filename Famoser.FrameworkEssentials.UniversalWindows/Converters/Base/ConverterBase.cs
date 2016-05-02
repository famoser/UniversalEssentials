using System;
using Windows.UI.Xaml.Data;

namespace Famoser.FrameworkEssentials.UniversalWindows.Converters.Base
{
    public abstract class ConverterBase : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, string language);

        public abstract object ConvertBack(object value, Type targetType, object parameter, string language);

        protected bool IsInverted(object parameter)
        {
            return parameter as string == "invert";
        }
    }
}
