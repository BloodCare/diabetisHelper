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

namespace MobileFramework.OverviewPlugin
{
    /// <summary>
    /// this is the System overview plugin Page viewModel which is connected to the AlarmPluginPage
    /// </summary>
    public class OverviewPluginPageModel : FreshBasePageModel, INotifyPropertyChanged
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
        public OverviewPluginPageModel()
        {
           // Name = PluginNames.OverviewPluginName;
            
            
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
