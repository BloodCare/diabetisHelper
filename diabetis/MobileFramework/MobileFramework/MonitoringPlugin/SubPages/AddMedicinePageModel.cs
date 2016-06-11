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

namespace MobileFramework.MonitoringPlugin.SubPages
{
    /// <summary>
    /// this is the System overview plugin Page viewModel which is connected to the AlarmPluginPage
    /// </summary>
    public class AddMedicinePageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        private string name;
        private string test;
        IPluginCollector pluginCollector;
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
        public AddMedicinePageModel(IPluginCollector _pluginCollector)
        {
            Name = "AddMedicine";
            pluginCollector = _pluginCollector;
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

        public void preSetFields()
        {
            Time = DateTime.Now.TimeOfDay;
            Date = DateTime.Now;
            MedicineUnits = Enum.GetNames(typeof(MedicineUnits)).ToList();
        }

        public List<string> MedicineUnits { get; set; }
        public string MedicineName { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public double MedicineAmount { get; set; }

        public int MedicineUnitIndex { get; set; }

        public Command AddDataPoint
        {
            get
            {
                //test notification
                return new Command(() =>
                {
                   MonitoringPluginSettingsModel tmpSettingsModel =  (MonitoringPluginSettingsModel) pluginCollector.SettingsModels.Where(x => x.Key == PluginNames.MonitoringPluginName).Select(x => x.Value).FirstOrDefault();
                    MedicineDataPoint tmpPoint = new MedicineDataPoint();
                    DateTime tmpDateTime = new DateTime(Date.Year, Date.Month, Date.Day, Time.Hours, Time.Minutes, Time.Seconds);
                    tmpPoint.Name = MedicineName;
                    tmpPoint.Amount = MedicineAmount;
                    tmpPoint.Unit = MedicineUnits[MedicineUnitIndex];
                    tmpPoint.Date = tmpDateTime;
                    tmpSettingsModel.MedicineDataPoints.Add(tmpPoint);

                    FreshMasterDetailNavigation nav = App.GetNavigationContainer();
                    nav.PopPage(false, true);
                });
            }
        }
        
    }
}
