using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using FreshMvvm;
using MobileFramework.MonitoringPlugin.Helpers;
using System.Globalization;
using System.Collections.ObjectModel;
using Syncfusion.SfChart.XForms;
using MobileFramework.MonitoringPlugin.SubPages;
using MobileFramework.Helpers;
using MobileFramework.Model;

namespace MobileFramework.MonitoringPlugin
{
    /// <summary>
    /// this is the System overview plugin Page viewModel which is connected to the AlarmPluginPage
    /// </summary>
    public class AddIngredientPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private string name;
        private string test;
        IPluginCollector pluginCollector;
        public event PropertyChangedEventHandler PropertyChanged;
        MonitoringPluginSettingsModel settingsModel;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// constructor of the Overview Plugin PageModel
        /// sets up eventhandler for structure refreshed event
        /// </summary>
        /// <param name="model"></param>
        public AddIngredientPageModel(IPluginCollector _pluginCollector)
        {
            Name = "AddIngredient";
            pluginCollector = _pluginCollector;
            
           settingsModel = (MonitoringPluginSettingsModel) pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MonitoringPluginName).Select(x => x.Value).FirstOrDefault();
            Ingredients = new List<Ingredient>();

         

        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
           
          
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            
        }

     
        ///</summary>
        /// returns the Name of the Plugin the PageModel is related to;
        /// </summary>
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string IngredientName { get; set; }

        public double Amount { get; set; }

        public double BreadUnits { get; set; }

        public double EnergyAmount { get; set; }

       public  List<Ingredient> Ingredients { get; set; }

        public Command AddIngredient
        {
            get
            {
                //test notification
                return new Command(() =>
                {
                    Ingredient tmpIngredient = new Ingredient();
                    tmpIngredient.Name = IngredientName;
                    tmpIngredient.amount = Amount;
                    tmpIngredient.BreadUnits = BreadUnits;
                    tmpIngredient.EnergyAmount = EnergyAmount;

                    Ingredients.Add(tmpIngredient);
                    FreshMasterDetailNavigation nav = App.GetNavigationContainer();
                    nav.PopPage(false, true);
                });
            }
        }

    }

    }

