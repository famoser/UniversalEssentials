using Windows.UI.Xaml;

namespace UniversalEssentials.Helpers
{
    public class ResolutionHelper
    {
        public static double WidthOfDevice
        {
            get { return Window.Current.Bounds.Width; }
        }

        public static double HeightOfDevice
        {
            get { return Window.Current.Bounds.Height; }
        }
    }
}
