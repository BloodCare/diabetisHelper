using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using MobileFramework.PluginManager;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderListPageModel : FreshMvvm.FreshBasePageModel
	{
		//IReminderDataService _reminderDataService;
		ReminderDataService _reminderDataService;

		public ReminderListPageModel (/*IReminderDataService reminderDataService */ )
		{
			ReminderDataService reminderDataService = new ReminderDataService ();
			_reminderDataService = reminderDataService;
		}
		public List<Reminder> ReminderList { get; set;}

		public override async void Init (object initData)
		{
			base.Init (initData);
			ReminderList = await _reminderDataService.GetReminders ();
		}
		public Reminder SelectedReminder{
			get{ return null;}
			set{ 
				CoreMethods.PushPageModel<ReminderPageModel> (value);
				RaisePropertyChanged ();
			}
		}

	}

}

