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
            //chart.PrimaryAxis.LabelCreated += PrimaryAxis_LabelCreated;


            // var test = Activator.CreateInstance((from KeyValuePair<String, Type> tmp in PluginCollector.Instance.Plugins where tmp.Key == "AlarmPlugin" select tmp.Value).FirstOrDefault());


        }


        /// <summary>
        /// set up the eventlistener to act when the station list in PageModel changed
        /// gets the PageModel
        /// </summary>
        protected  override void OnAppearing()
        {
            model = (MonitoringPluginPageModel)this.BindingContext;
            
        }


        void PrimaryAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            DateTime date = DateTime.Parse(e.LabelContent);

            e.LabelContent = date.DayOfWeek.ToString().Substring(0, 2) + " \n" + date.ToString("dd MMM");
            
        }
        
        /// <summary>
        /// unsubscibes the property changed event when view is closed
        /// </summary>
        protected override void OnDisappearing()
        {
      
        }


        
    }
}
