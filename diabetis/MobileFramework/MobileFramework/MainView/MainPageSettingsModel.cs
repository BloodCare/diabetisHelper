using MobileFramework.Navigation;
using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.MainView
{
    class MainPageSettingsModel : SettingsModel
    {
        private static MainPageSettingsModel instance;

        public static MainPageSettingsModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainPageSettingsModel();
                }
                return instance;
            }
        }

        public MainPageSettingsModel()
        {
            instance = this;
           // Name = PluginNames.MainPluginName;
          //  SideBarItem = new NavigationSideBarItem() { Title = PluginNames.MainPluginName, Icon = new Image { Aspect = Aspect.AspectFit, Source= ImageSource.FromFile("msm.jpg")}};
        }

       
        //public string Name = "Main Settings";
    }
}
