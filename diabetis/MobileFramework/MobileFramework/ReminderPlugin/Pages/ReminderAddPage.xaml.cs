using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MobileFramework.PluginManager;
using System.Diagnostics;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderAddPage : ContentPage
	{


		private List<String> fplist;
		ReminderAddPageModel model;

		public ReminderAddPage ()
		{
			InitializeComponent ();
			this.BindingContext = new ReminderAddPageModel ();

		}



		protected  override void OnAppearing()
		{
			model = (ReminderAddPageModel)this.BindingContext;
			fplist = new List<string>(FeaturePicker.Items);
			model.featureList = (List<String>) fplist;
			model.preSetFields ();
		}


	}
}

