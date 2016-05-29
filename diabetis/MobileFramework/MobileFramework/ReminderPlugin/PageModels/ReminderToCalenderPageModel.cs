using System;
using System.Collections.Generic;
using System.ComponentModel;
using MobileFramework.PluginManager;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderToCalenderPageModel : FreshMvvm.FreshBasePageModel
	{
		public ReminderToCalenderPageModel ()
		{
			
		}

		public Command onCancel
		{
			get
			{
				//test notification
				return new Command( (value) =>
					{
						CoreMethods.PushPageModel<ReminderListPageModel> (value);
					});
			}
		}

		public Command onSave
		{
			get
			{
				//test notification
				return new Command( (value) =>
					{
						CoreMethods.PushPageModel<ReminderListPageModel> (value);
					});
			}
		}
	}
}


