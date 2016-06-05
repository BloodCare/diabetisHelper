using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderToCalenderPage : ContentPage
	{
		private ReminderToCalenderPageModel model;
		public ReminderToCalenderPage ()
		{
			InitializeComponent ();
			var fplist =  FeaturePicker1.Items;
			model = (ReminderToCalenderPageModel)this.BindingContext;
			model.featureList = (List<String>) fplist;

		}

		protected  override void OnAppearing()
		{
			model = (ReminderToCalenderPageModel)this.BindingContext;
			model.preSetFields();
		}
	}
}

