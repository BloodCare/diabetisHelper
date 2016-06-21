using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using FreshMvvm;

namespace MobileFramework.UserProfilePlugin
{
	public class UserProfilePageModel : FreshBasePageModel
	{
		public UserProfilePageModel ()
		{
		}

		public Command saveReminder
		{
			get
			{
				return new Command((value) =>
					{
						CoreMethods.PopToRoot(true);
					});
			}
		}

		public Command cancelReminder
		{
			get
			{
				return new Command((value) =>
					{
						CoreMethods.PopToRoot(true);
					});
			}
		}
	}
}

