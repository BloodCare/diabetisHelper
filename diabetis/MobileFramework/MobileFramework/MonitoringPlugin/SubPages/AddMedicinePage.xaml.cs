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
    public partial class AddMedicinePage : ContentPage
    {
        private AddMedicinePageModel model;
        public AddMedicinePage(IPluginCollector pluginCollector)
        {
            this.BindingContext = new AddMedicinePageModel(pluginCollector);
            InitializeComponent();
        }

        public AddMedicinePage(IPluginCollector pluginCollector, MedicineDataPoint point)
        {
            this.BindingContext = new AddMedicinePageModel(pluginCollector, point);
            InitializeComponent();
        }


        /// <summary>
        /// set up the eventlistener to act when the station list in PageModel changed
        /// gets the PageModel
        /// </summary>
        protected  override void OnAppearing()
        {
            model = (AddMedicinePageModel)this.BindingContext;
            model.preSetFields();

            foreach (var entry in Enum.GetNames(typeof(MedicineUnits)).ToList())
            {
                medPicker.Items.Add(entry);
            }
        }


        
        /// <summary>
        /// unsubscibes the property changed event when view is closed
        /// </summary>
        protected override void OnDisappearing()
        {
      
        }


    }
}
