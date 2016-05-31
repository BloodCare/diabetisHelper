using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using MobileFramework.PluginManager;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderAddPageModel : FreshMvvm.FreshBasePageModel
	{
		public ReminderAddPageModel ()
		{
		}
		public Command onCancel
		{
			get
			{
				//test notification
				return new Command( (value) =>
					{
						CoreMethods.PopToRoot(true);
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
						CoreMethods.PopToRoot(true);
					});
			}
		}
			
	}
}

