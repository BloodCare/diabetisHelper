using FreshMvvm;
using MobileFramework.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.Helpers
{
    /// <summary>
    /// Navigation Overview Page
    /// Contains a Master (sidebar for navigation) and a detail Page which is selected by the sidebar
    /// </summary>
    public class FreshMasterDetailNavigation : Xamarin.Forms.MasterDetailPage, IFreshNavigationService
    {
            Dictionary<string, Page> _pages = new Dictionary<string, Page>();
            ContentPage _menuPage;
            ObservableCollection<string> _pageNames = new ObservableCollection<string>();

            public FreshMasterDetailNavigation()
            {
            }

            public void Init(string menuTitle)
            {
                RegisterNavigation();
            }

            protected virtual void RegisterNavigation()
            {
                FreshIOC.Container.Register<IFreshNavigationService>(this);
            }

        /// <summary>
        /// adding Plugin Pages to the list and automatically to the sidebarnavigation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title"></param>
        /// <param name="data"></param>
            public virtual void AddPage<T>(string title, object data = null) where T : FreshBasePageModel
            {
                var page = FreshPageModelResolver.ResolvePageModel<T>(data);
                var navigationContainer = CreateContainerPage(page);
                if(_pages.ContainsKey(title)== false)
                {
                    _pages.Add(title, navigationContainer);
                    _pageNames.Add(title);
                }
                if (_pages.Count == 1)
                    Detail = navigationContainer;
            }

            protected virtual Page CreateContainerPage(Page page)
            {
                return new Xamarin.Forms.NavigationPage(page);
            }

        /// <summary>
        /// sets the sidebar Page layout
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="menuPageTitle"></param>
            public virtual void CreateMenuPage<T>(string menuPageTitle) where T : FreshBasePageModel
            {
                object data = null;
                var page = FreshPageModelResolver.ResolvePageModel<T>(data);
                var navigationContainer = CreateContainerPage(page);
                //_menuPage.Content = listView;
                navigationContainer.Title = "Menu";
                Master = navigationContainer;
            }

        /// <summary>
        /// sets the detail Page on base of selected item and page list
        /// </summary>
        /// <param name="selectedItem"></param>
        public  virtual void ChangeDetailPage(NavigationSideBarItem selectedItem)
            {
                if (_pages.ContainsKey(selectedItem.Title))
                {
                   Detail = _pages[selectedItem.Title];
                }

                IsPresented = false;
            }

        public virtual void ChangeDetailPage(string pluginName)
        {
            if (_pages.ContainsKey(pluginName))
            {
                Detail = _pages[pluginName];
            }

            IsPresented = false;
        }

            public async Task PushPage(Page page, FreshBasePageModel model, bool modal = false, bool animate = true)
            {
                if (modal)
                    await Navigation.PushModalAsync(new Xamarin.Forms.NavigationPage(page));
                else
                    await (Detail as Xamarin.Forms.NavigationPage).PushAsync(page, animate); //TODO: make this better
            }

            public async Task PopPage(bool modal = false, bool animate = true)
            {
                if (modal)
                    await Navigation.PopModalAsync(animate);
                else
                    await (Detail as Xamarin.Forms.NavigationPage).PopAsync(animate); //TODO: make this better
            }

            public async Task PopToRoot(bool animate = true)
            {
                await (Detail as Xamarin.Forms.NavigationPage).PopToRootAsync(animate);
            }
        
    }
}
