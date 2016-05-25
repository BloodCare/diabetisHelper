using FreshMvvm;
using MobileFramework.Helpers;
using MobileFramework.MainView;
using MobileFramework.MonitoringPlugin;
using MobileFramework.Navigation;
using MobileFramework.OverviewPlugin;
using MobileFramework.PluginManager;
using Xamarin.Forms;
using MobileFramework.ReminderPlugin;

namespace MobileFramework
{
    public class App : Application
    {
        /// <summary>
        /// entrypoint into the Xamarin forms application
        /// a master-detail page is created and the plugins are added as subpages
        /// at the end it initializes the main page
        /// </summary>
        public App(string pluginName)
        {
            //register PluginCollector in IoC container for constructorinjection
            FreshIOC.Container.Register<IPluginCollector, PluginCollector>();

            masterDetailNav = new FreshMasterDetailNavigation();
            masterDetailNav.Init("Menu");

            //every Plugin has to be added like these
            masterDetailNav.AddPage<MainPageModel>(PluginNames.MainPluginName, null);
            masterDetailNav.AddPage<OverviewPluginPageModel>(PluginNames.OverviewPluginName, null);
            masterDetailNav.AddPage<MonitoringPluginPageModel>(PluginNames.MonitoringPluginName, null);
			masterDetailNav.AddPage<ReminderPluginPageModel>(PluginNames.ReminderPluginName, null);


            //initialises the navigation Page
            masterDetailNav.CreateMenuPage<NavigationPageModel>(null);
            masterDetailNav.Init("Plugins");
            MainPage =masterDetailNav;

            //is filled by the start via notification 
            if(pluginName != null)
            {
                masterDetailNav.ChangeDetailPage(pluginName);
            }
            
        }

        private static FreshMasterDetailNavigation masterDetailNav;
        public static FreshMasterDetailNavigation GetNavigationContainer()
        {
            return masterDetailNav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            base.OnResume();
        }
    }
}
