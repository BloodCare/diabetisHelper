using System;
using PropertyChanged;

namespace MobileFramework.ReminderPlugin
{
	[ImplementPropertyChanged]
	public class Reminder
	{
		public Reminder ()
		{
		}
		public string Name {
			get;
			set;
		}
		public string Description {
			get;
			set;
		}
		public bool isActive {
			get;
			set;
		}
		public string LinkToFeature{
			get;
			set;
		}
		public DateTime OnDate {
			get;
			set;
		}


	}
}

