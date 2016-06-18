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
using MobileFramework.Helpers;
using MobileFramework.Model;

namespace MobileFramework.MonitoringPlugin.SubPages
{
    /// <summary>
    /// this is the System overview plugin Page viewModel which is connected to the AlarmPluginPage
    /// </summary>
    public class AddMealPageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private string name;
        private string test;
        IPluginCollector pluginCollector;
        public event PropertyChangedEventHandler PropertyChanged;

        AddIngredientPage ingredientPage;
        AddIngredientPageModel ingredientPageModel;
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
        public AddMealPageModel(IPluginCollector _pluginCollector)
        {
            Name = "AddMeal";
            pluginCollector = _pluginCollector;
            Ingredients = new List<Ingredient>();
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {


        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            if(ingredientPage != null && ingredientPageModel != null)
            {
                List<Ingredient> tmpList = new List<Ingredient>();
                tmpList.AddRange(Ingredients);
                tmpList.Add(ingredientPageModel.Ingredient);
                Ingredients = tmpList;

                BreadUnits = 0;
                EnergyAmount = 0;
                foreach (Ingredient ing in Ingredients)
                {
                    BreadUnits = BreadUnits + ing.BreadUnits;
                    EnergyAmount = EnergyAmount + ing.EnergyAmount;
                }
            }
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

        public void preSetFields()
        {
            if (Time.Days +Time.Hours + Time.Minutes == 0  && Date == new DateTime(1900,1,1 ))
            {
                Time = DateTime.Now.TimeOfDay;
                Date = DateTime.Now;
            }
        }

        public double BreadUnits { get; set; }

        public double EnergyAmount { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Command AddDataPoint
        {
            get
            {
                //test notification
                return new Command(() =>
                {
                   MonitoringPluginSettingsModel tmpSettingsModel =  (MonitoringPluginSettingsModel) pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MonitoringPluginName).Select(x => x.Value).FirstOrDefault();
                    MealDataPoint tmpPoint = new MealDataPoint();
                    DateTime tmpDateTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, Time.Seconds);
                    
                    tmpPoint.BreadUnits = BreadUnits;
                    tmpPoint.EnergyAmount = EnergyAmount;
                    tmpPoint.Date = tmpDateTime;
                    tmpPoint.Ingredients = Ingredients;
                    tmpSettingsModel.MealDataPoints.Add(tmpPoint);

                    FreshMasterDetailNavigation nav = App.GetNavigationContainer();
                    nav.PopPage(false, true);
                });
            }
        }

        public Command AddIngredient
        {
            get
            {
                //test notification
                return new Command(async ()  =>
                {
                    ingredientPageModel = new AddIngredientPageModel(pluginCollector);
                    ingredientPage = new AddIngredientPage(ingredientPageModel);

                    FreshMasterDetailNavigation nav = App.GetNavigationContainer();
                    await nav.PushPage(ingredientPage, null, false, true);
                });
            }
        }

    }
}
