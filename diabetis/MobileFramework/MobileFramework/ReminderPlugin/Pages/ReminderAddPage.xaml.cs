using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderAddPage : ContentPage
	{

		public static string nName = string.Empty;
		public static string nDescription = string.Empty;
		private ReminderAddPageModel model;

		public ReminderAddPage ()
		{
			InitializeComponent ();
			var fplist =  FeaturePicker.Items;
			model = (ReminderAddPageModel)this.BindingContext;
			model.featureList = (List<String>) fplist;

		}

		protected  override void OnAppearing()
		{
			model = (ReminderAddPageModel)this.BindingContext;
			model.preSetFields();
		}


	}
}

