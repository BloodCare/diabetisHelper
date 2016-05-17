using FreshMvvm;
using MobileFramework.Helpers;
using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileFramework.OverviewPlugin;
using MobileFramework.Model;

namespace MobileFramework.Navigation
{
    /// <summary>
    /// this is the ViewModel of the SideBar(NavigationPage).
    /// </summary>
    
    public class NavigationPageModel : FreshBasePageModel
    {
        IPluginCollector pluginCollector;
        SettingsModel mainSettingsModel;
       
        /// <summary>
        /// loads the PluginCollector and the list of the SettingsModels to a local variable
        /// </summary>
        /// <param name="pluginCollector"></param>
        public NavigationPageModel(IPluginCollector pluginCollector)
        {
            pluginCollector = pluginCollector;
            mainSettingsModel = pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MainPluginName).Select(x => x.Value).First();
            List<SettingsModel> settingsModels = pluginCollector.SettingsModels.Values.ToList();
            NavigationItems = (from item in settingsModels select item.SideBarItem).ToList();
        }

        /// <summary>
        /// inits the SideBaritems
        /// </summary>
        /// <param name="initData"></param>
        public override void Init(object initData)
        {
            
           
            
        }

        /// <summary>
        /// returns a list of all navigation sidbar items
        /// </summary>
        public List<NavigationSideBarItem> NavigationItems { get; set; }

        private NavigationSideBarItem _selectedItem;

        /// <summary>
        /// Property of the selected Item calls ItemSelected command
        /// </summary>
        public NavigationSideBarItem SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (value != null)
                    ItemSelected.Execute(value);
            }
        }

        /// <summary>
        /// the ItemSelectedComand loads the MainLayoutView of the App and calls its function to change the DetailPage
        /// </summary>
        public Command<NavigationSideBarItem> ItemSelected
        {
            get
            {
                return new Command<NavigationSideBarItem>( (item) =>
                {
                   FreshMasterDetailNavigation navigationmodel =  App.GetNavigationContainer();
                   navigationmodel.ChangeDetailPage(item);
                    
                   // await navigationmodel.PushPage(new OverviewPluginPage(), new OverviewPluginPageModel(new GlobalModel()));
                });
            }
        }

    }
}
