﻿using MobileFramework.MonitoringPlugin.Helpers;
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
   
    public partial class AddMealPage : ContentPage
    {
        private AddMealPageModel model;
        public AddMealPage(IPluginCollector pluginCollector)
        {
            this.BindingContext = new AddMealPageModel(pluginCollector);
            model = (AddMealPageModel)this.BindingContext;
            model.WireEvents(this);
            InitializeComponent();
        }

        public AddMealPage(IPluginCollector pluginCollector, MealDataPoint point)
        {
            this.BindingContext = new AddMealPageModel(pluginCollector, point);
            model = (AddMealPageModel)this.BindingContext;
            model.WireEvents(this);
            InitializeComponent();
        }


        /// <summary>
        /// set up the eventlistener to act when the station list in PageModel changed
        /// gets the PageModel
        /// </summary>
        protected  override void OnAppearing()
        {
            
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
