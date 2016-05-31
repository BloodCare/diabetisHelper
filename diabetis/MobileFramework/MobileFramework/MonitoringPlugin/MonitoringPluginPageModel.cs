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
        public event PropertyChangedEventHandler PropertyChanged;
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
        public MonitoringPluginPageModel()
        {
            Name = PluginNames.MonitoringPluginName;

            BloodSugarDataPoints = new ObservableCollection<ChartDataPoint>();
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 8, 33, 0), 56));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 12, 45, 0), 80));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 18, 15, 0), 76));
            
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 8, 0, 0), 90));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 11, 37, 0), 66));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 16, 9, 0), 60));
            
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 6, 30, 0), 40));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 13, 0, 0), 70));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 22, 20, 0), 88));
           
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 26, 8, 33, 0), 45));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 27, 8, 33, 0), 97));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 28, 8, 33, 0), 42));
            BloodSugarDataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 29, 8, 33, 0), 74));


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
           switch(point)
            {
                case DataPoints.BloodSugar:
                    FreshMasterDetailNavigation nav=  App.GetNavigationContainer();
                    await nav.PushPage(new AddBloodSugarPage(), null, false, true);
                    //CoreMethods.PushPageModel<AddBloodSugarPageModel>(null, true);
                    break;

                case DataPoints.Meal:

                    break;

                case DataPoints.Medicine:

                    break;
            }
        }

    }
}
