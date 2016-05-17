using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.PluginManager
{
    /// <summary>
    /// this View is the parent class of the widget that every Plugins publish to the App
    /// it defines the main properties of the widgets
    /// </summary>
    public class WidgetView : View
    {
        public Tuple<int, int> WidgetSize { get; set; }
      
    }
}
