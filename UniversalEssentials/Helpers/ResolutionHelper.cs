using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Famoser.FrameworkEssentials.Singleton;

namespace UniversalEssentials.Helpers
{
    public class ResolutionHelper : SingletonBase<ResolutionHelper>
    {
        public double WidthOfDevice
        {
            get { return Window.Current.Bounds.Width; }
        }

        public double HeightOfDevice
        {
            get { return Window.Current.Bounds.Height; }
        }
    }
}
