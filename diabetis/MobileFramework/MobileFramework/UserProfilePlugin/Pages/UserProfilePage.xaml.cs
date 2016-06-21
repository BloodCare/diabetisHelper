using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileFramework.UserProfilePlugin
{
	public partial class UserProfilePage : ContentPage
	{
		UserProfilePageModel model;
		public UserProfilePage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
			model = (UserProfilePageModel)this.BindingContext;
		}
	}
}

