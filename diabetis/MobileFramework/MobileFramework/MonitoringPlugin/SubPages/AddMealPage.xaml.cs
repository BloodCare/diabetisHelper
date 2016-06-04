using MobileFramework.MonitoringPlugin.Helpers;
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

namespace MobileFramework.MonitoringPlugin.SubPages
{
    /// <summary>
    /// the entry point of the alarmplugin, which will be called from navigation in master detail view
    /// </summary>
    public partial class AddMealPage : ContentPage
    {
        private AddMealPageModel model;
        public AddMealPage(IPluginCollector pluginCollector)
        {
            this.BindingContext = new AddMealPageModel(pluginCollector);
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
            model = (AddMealPageModel)this.BindingContext;
            model.preSetFields();
        }


        
        /// <summary>
        /// unsubscibes the property changed event when view is closed
        /// </summary>
        protected override void OnDisappearing()
        {
      
        }

       
        

    }
}
