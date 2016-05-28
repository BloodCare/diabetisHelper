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

            DataPoints = new ObservableCollection<ChartDataPoint>();
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 8, 33, 0), 56));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 12, 45, 0), 80));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 18, 15, 0), 76));
            
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 8, 0, 0), 90));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 11, 37, 0), 66));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 16, 9, 0), 60));
            
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 6, 30, 0), 40));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 13, 0, 0), 70));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 22, 20, 0), 88));
           
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 26, 8, 33, 0), 45));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 27, 8, 33, 0), 97));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 28, 8, 33, 0), 42));
            DataPoints.Add(new ChartDataPoint(new DateTime(2016, 5, 29, 8, 33, 0), 74));


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

        public ObservableCollection<ChartDataPoint> DataPoints
        {
            get;
            set;
            }


        public Command DoSthCommand
        {
            get
            {
                //test notification
                return new Command( () =>
                {
                   
                });
            }
        }

    }
}
