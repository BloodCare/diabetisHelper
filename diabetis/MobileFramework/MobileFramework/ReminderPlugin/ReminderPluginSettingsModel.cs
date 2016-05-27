using MobileFramework.Navigation;
using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
    /// <summary>
    /// This is the OverviewPluginSettingsModel
    /// her the NavigationSideBarItem and the global Plugin Widget should be stored (all stuff that should be usable in other Plugins)
    /// SettingsModels should be singletons, that there is always consistence for the Settings
    /// </summary>
	class ReminderPluginSettingsModel : SettingsModel
    {
        /// <summary>
        /// constructor of the SettingsModel
        /// inits the name and the sidbaritem
        /// </summary>
		public ReminderPluginSettingsModel()
        {
            Name = PluginNames.ReminderPluginName;
            SideBarItem = new NavigationSideBarItem() { Title = Name, Icon = new Image { Aspect = Aspect.AspectFit, Source= ImageSource.FromFile("msm.jpg" )}};
        }

        public WidgetView AlarmWidget { get; set; }
    }
}
