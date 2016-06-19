using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MobileFramework.PluginManager;
using System.Diagnostics;
using Acr.UserDialogs;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderAddPage : ContentPage
	{


		private List<String> fplist;
		ReminderAddPageModel model;
		IUserDialogs userDialogs;

		public ReminderAddPage()
		{
			InitializeComponent();
			this.BindingContext = new ReminderAddPageModel(userDialogs);
			btnRingtoneSelect.Clicked += (sender, e) =>
			{

				DependencyService.Get<IAndroidRingtoneSelector>().startRingtonePicker();
			};
		}



		protected override void OnAppearing()
		{
			model = (ReminderAddPageModel)this.BindingContext;
			fplist = new List<string>(FeaturePicker.Items);
			model.featureList = (List<String>)fplist;
		}


	}
}

