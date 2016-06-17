using MobileFramework.Model;
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
            addDatapoints_Button.Command = AddDatapoints;
            
            
        }

        public void on_SelectedIndexChangedBs(object sender, ChartSelectionEventArgs e)
        {
            if( e.SelectedSeries.Label == "Bloodsugar")
            {

            }
            if (e.SelectedSeries.Label == "Meal")
            {
                MealDataPoint mealPoint = model.SettingsModel.MealDataPoints[e.SelectedDataPointIndex];

                string content = "";
                    content= "Total BreadUnits: " + mealPoint.BreadUnits + "\t\t\t\t" +  "Total Energy: " + mealPoint.EnergyAmount + " kcal" + "\n\n";

                foreach(Ingredient ing in mealPoint.Ingredients)
                {
                    content += ing.Name + "\n"
                             + "Breadunits: " + ing.BreadUnits + "\t\t" + "Energy: " + ing.EnergyAmount + "\t\t" + "Amount: " + ing.amount + "\n\n";
                }
                    var action = DisplayAlert("Meal:", content, "Edit", "Back");
                
            }

            if (e.SelectedSeries.Label == "Med")
            {
                MedicineDataPoint medPoint = model.SettingsModel.MedicineDataPoints[e.SelectedDataPointIndex];
                var action = DisplayAlert("Medicine:",medPoint.Name +": " + medPoint.Amount +" "+ medPoint.Unit  , "Edit", "Back");
            }

        }
        
       
        public void PrimaryAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
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

        public Command AddDatapoints
        {
            get
            {
                return new Command(async () =>
                {
                var action = await DisplayActionSheet("Add:", "Cancel", null, DataPoints.BloodSugar.ToString(), DataPoints.Meal.ToString(), DataPoints.Medicine.ToString());

                    if (action == DataPoints.BloodSugar.ToString())
                    {
                        model.AddDatapoints(DataPoints.BloodSugar);
                    }
                    else if (action == DataPoints.Meal.ToString())
                    {
                        model.AddDatapoints(DataPoints.Meal);
                    }
                    else if (action == DataPoints.Medicine.ToString())
                    {
                        model.AddDatapoints(DataPoints.Medicine);
                    }

                });
            }
        }

    }
}
