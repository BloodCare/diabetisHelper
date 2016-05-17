using FreshMvvm;
using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.MainView
{
    /// <summary>
    /// this is the main page view model (Dashboard) which is the standard startup page
    /// </summary>
    public class MainPageModel : FreshBasePageModel
    {
        public String Name { get; set; }

        
        IPluginCollector _pluginCollector;

        SettingsModel settingsModel;

        /// <summary>
        /// gets all settingsmodel from the plugincollector to get the widgets on application start
        /// </summary>
        /// <param name="pluginCollector"></param>
        public MainPageModel(IPluginCollector pluginCollector)
        {
            Name = "MainPlugin";
            _pluginCollector = pluginCollector;
            settingsModel = _pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MainPluginName).Select(x => x.Value).First();

        }

    }
}
