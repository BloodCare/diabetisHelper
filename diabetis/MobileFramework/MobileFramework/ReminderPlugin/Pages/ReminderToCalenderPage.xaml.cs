using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderToCalenderPage : ContentPage
	{
		private List<String> fplist;
		ReminderToCalenderPageModel model;
		IUserDialogs userDialogs;

		public ReminderToCalenderPage ()
		{
			InitializeComponent ();
			this.BindingContext = new ReminderToCalenderPageModel (userDialogs);

			/*btnSaveReminder.Clicked += (sender, e) => {

				DependencyService.Get<IReminderService>().Remind(name.Text,description.Text,date.Date,time.Time);
			};*/


		}

		protected  override void OnAppearing()
		{
			model = (ReminderToCalenderPageModel)this.BindingContext;
		}
	}
}

