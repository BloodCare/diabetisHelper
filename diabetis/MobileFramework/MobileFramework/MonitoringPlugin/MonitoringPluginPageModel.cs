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

namespace MobileFramework.MonitoringPlugin
{
    /// <summary>
    /// this is the System overview plugin Page viewModel which is connected to the AlarmPluginPage
    /// </summary>
    public class MonitoringPluginPageModel : FreshBasePageModel, INotifyPropertyChanged
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
        public MonitoringPluginPageModel(IPluginCollector _pluginCollector)
        {
            Name = PluginNames.MonitoringPluginName;
            pluginCollector = _pluginCollector;
            BloodSugarDataPoints = new ObservableCollection<ChartDataPoint>();
           settingsModel = (MonitoringPluginSettingsModel) pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MonitoringPluginName).Select(x => x.Value).FirstOrDefault();


            MealDataPoints = new ObservableCollection<ChartDataPoint>();
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 8, 33, 0), 56 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 12, 45, 0), 80 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 18, 15, 0), 76 + 10));
            
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 8, 0, 0), 90 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 11, 37, 0), 66 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 16, 9, 0), 60 + 10));
            
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 6, 30, 0), 40 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 13, 0, 0), 70 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 22, 20, 0), 88 + 10));
            
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 26, 8, 33, 0), 45 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 27, 8, 33, 0), 97 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 28, 8, 33, 0), 42 + 10));
            MealDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 29, 8, 33, 0), 74 + 10));

        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
           
          
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            BloodSugarDataPoints.Clear();
          foreach(BloodSugarDataPoint tmpPoint in settingsModel.BloodSugarDataPoints)
            {
                BloodSugarDataPoints.Add(new ChartDataPoint(tmpPoint.Date, tmpPoint.BloodSugarLevel));
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

        public ObservableCollection<ChartDataPoint> BloodSugarDataPoints
        {
            get;
            set;
            }

        public ObservableCollection<ChartDataPoint> MealDataPoints
        {
            get;
            set;
        }
        public ObservableCollection<ChartDataPoint> MedDataPoints
        {
            get;
            set;
        }

        public async void AddDatapoints(DataPoints point)
        {
            FreshMasterDetailNavigation nav = App.GetNavigationContainer();
            switch (point)
            {
                case DataPoints.BloodSugar:
                    
                    await nav.PushPage(new AddBloodSugarPage(pluginCollector), null, false, true);
                    //CoreMethods.PushPageModel<AddBloodSugarPageModel>(null, true);
                    break;

                case DataPoints.Meal:
                    await nav.PushPage(new AddMealPage(pluginCollector), null, false, true);
                    break;

                case DataPoints.Medicine:
                    await nav.PushPage(new AddMedicinePage(pluginCollector), null, false, true);
                    break;
            }
        }

    }
}
