﻿using System;
using Famoser.FrameworkEssentials.UniversalWindows.Converters.Base;

namespace Famoser.FrameworkEssentials.UniversalWindows.Converters.Visibility
{
    public class BoolToVisibilityConverter : ConverterBase
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
