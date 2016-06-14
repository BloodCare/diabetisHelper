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
            BloodSugarDataPoints = new List<ChartDataPoint>();
            MealDataPoints = new ObservableCollection<ChartDataPoint>();
            MedDataPoints = new ObservableCollection<ChartDataPoint>();
            settingsModel = (MonitoringPluginSettingsModel) pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MonitoringPluginName).Select(x => x.Value).FirstOrDefault();
            
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
           
          
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            BloodSugarDataPoints.Clear();
            foreach (BloodSugarDataPoint tmpPoint in settingsModel.BloodSugarDataPoints)
            {
                ChartDataPoint point = new ChartDataPoint(tmpPoint.Date, tmpPoint.BloodSugarLevel);

                BloodSugarDataPoints.Add(point);
            }


            foreach (MealDataPoint tmpPoint in settingsModel.MealDataPoints)
            {
                ChartDataPoint point = new ChartDataPoint(tmpPoint.Date, 0);
                point.YValue = calcDataPointsYValue(point);
                tmpPoint.YValue = point.YValue;
                MealDataPoints.Add(point);
            }
            BloodSugarDataPoints = BloodSugarDataPoints.OrderBy(o => o.XValue).ToList();

            foreach (MedicineDataPoint tmpPoint in settingsModel.MedicineDataPoints)
            {
                ChartDataPoint point = new ChartDataPoint(tmpPoint.Date, 0);
                point.YValue = calcDataPointsYValue(point);
                tmpPoint.YValue = point.YValue;
                MedDataPoints.Add(point);
            }
        }
        public double calcDataPointsYValue(ChartDataPoint point)
        {
            List<ChartDataPoint> tmpList = new List<ChartDataPoint>(BloodSugarDataPoints);
            tmpList.Add(point);
            tmpList = tmpList.OrderBy(o => o.XValue).ToList();
            
            int index = tmpList.IndexOf(point);
            if (index > 0)
            {

                double yValAncestor = tmpList[index - 1].YValue;
                double xValAncetor = ((DateTime)tmpList[index - 1].XValue).Ticks;
                double yValFollower = tmpList[index + 1].YValue;
                double xValFollower = ((DateTime)tmpList[index + 1].XValue).Ticks;
                double xPoint = ((DateTime)point.XValue).Ticks;
                double m = (yValFollower - yValAncestor) / (xValFollower - xValAncetor);
                double y = m * (xPoint - xValAncetor) + yValAncestor;
                point.YValue = y;
            }

            return point.YValue;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
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

        public List<ChartDataPoint> BloodSugarDataPoints
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
