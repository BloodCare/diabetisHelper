using System;
using MobileFramework;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderEditPageModel : FreshMvvm.FreshBasePageModel
	{
		public ReminderEditPageModel ()
		{
		}

		public Reminder Reminder { get; set;}

		public override void Init (object initData)
		{
			base.Init (initData);
			Reminder = initData as Reminder;
		}


		public Command saveReminder
		{
			get
			{
				return new Command((value) =>
					{

						//var reminder = CreateNewReminder();
						//rds.AddReminder(reminder);
						//_rDateTime = new DateTime(_Date.Year, _Date.Month, _Date.Day, _Time.Hours, _Time.Minutes, _Time.Seconds);
						//setreminder(_rName, _rDescription, _rDateTime);
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

