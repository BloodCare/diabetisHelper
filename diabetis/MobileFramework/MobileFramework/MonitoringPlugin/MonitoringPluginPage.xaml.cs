using MobileFramework.PluginManager;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.MonitoringPlugin
{
    /// <summary>
    /// the entry point of the alarmplugin, which will be called from navigation in master detail view
    /// </summary>
    public partial class MonitoringPluginPage : ContentPage
    {
        private MonitoringPluginPageModel model;
        private readonly ObservableCollection<ChartDataPoint> data = new ObservableCollection<ChartDataPoint>();

        private SfChart chart;
        LineSeries lineSeries;
        public MonitoringPluginPage()
        {
           
            InitializeComponent();
            // var test = Activator.CreateInstance((from KeyValuePair<String, Type> tmp in PluginCollector.Instance.Plugins where tmp.Key == "AlarmPlugin" select tmp.Value).FirstOrDefault());

           
        }

      
        /// <summary>
        /// set up the eventlistener to act when the station list in PageModel changed
        /// gets the PageModel
        /// </summary>
        protected  override void OnAppearing()
        {
            model = (MonitoringPluginPageModel)this.BindingContext;
            chart = new SfChart();

            data.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 8, 33, 0), 56));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 12, 45, 0), 80));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 23, 18, 15, 0), 76));

            data.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 8, 0, 0), 90));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 11, 37, 0), 66));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 24, 16, 9, 0), 60));

            data.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 6, 30, 0), 40));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 13, 0, 0), 70));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 25, 22, 20, 0), 88));

            data.Add(new ChartDataPoint(new DateTime(2016, 5, 26, 8, 33, 0), 45));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 27, 8, 33, 0), 97));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 28, 8, 33, 0), 42));
            data.Add(new ChartDataPoint(new DateTime(2016, 5, 29, 8, 33, 0), 74));

            DateTimeAxis dateAxis = new CategoryAxis() {LabelPlacement = LabelPlacement.BetweenTicks,IntervalType = DateTimeIntervalType.Days, Interval = 1};
            //dateAxis.Minimum = 1;
            //dateAxis.Maximum = 7;
            ChartAxisLabelStyle style = new ChartAxisLabelStyle();
            style.LabelFormat  = LabelPlacement.BetweenTicks;
            dateAxis.LabelStyle = style;
            chart.PrimaryAxis.LabelStyle = style;
            chart.PrimaryAxis = dateAxis;

            var axis = new NumericalAxis();
            chart.SecondaryAxis = axis;

            lineSeries = new LineSeries { ItemsSource = data };
            chart.Series.Add(lineSeries);

            grid.Children.Add(chart, 0, 0);


        }



        /// <summary>
        /// unsubscibes the property changed event when view is closed
        /// </summary>
        protected override void OnDisappearing()
        {
      
        }


        
    }
}
