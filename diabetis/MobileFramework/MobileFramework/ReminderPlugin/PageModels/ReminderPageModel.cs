using System;
using MobileFramework;

namespace MobileFramework.ReminderPlugin 
{
	public class ReminderPageModel :  FreshMvvm.FreshBasePageModel
	{
		public ReminderPageModel ()
		{
		}
		public Reminder Reminder { get; set;}

		public override void Init (object initData)
		{
			base.Init (initData);
			Reminder = initData as Reminder;
		}
	}
}

