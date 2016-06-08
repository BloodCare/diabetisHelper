using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderToCalenderPage : ContentPage
	{
		private List<String> fplist;
		ReminderToCalenderPageModel model;

		public ReminderToCalenderPage ()
		{
			InitializeComponent ();
			this.BindingContext = new ReminderToCalenderPageModel ();

		}

		protected  override void OnAppearing()
		{
			model = (ReminderToCalenderPageModel)this.BindingContext;
			fplist =  new List<string>(FeaturePicker1.Items);
			model.featureList = (List<String>) fplist;
			model.preSetFields();
		}
	}
}

