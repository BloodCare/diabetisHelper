using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileFramework.Navigation;
using Xamarin.Forms;
namespace MobileFramework.PluginManager
{
    /// <summary>
    /// all stuff from a plugin that should global avaiable for is saved in the SettingsModel
    /// this is the parentClass to define the must haves of the SettingsModel
    /// </summary>
    public class SettingsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// returns the sidebaritem, that will be displayed in the navigation Page
        /// </summary>
        public NavigationSideBarItem SideBarItem { get; set; }

        /// <summary>
        /// returns the name of the plugin, this SettingsModel is realted to
        /// </summary>
        public string Name { get; set; }

        public WidgetView Widget { get; set; }
    }
}
