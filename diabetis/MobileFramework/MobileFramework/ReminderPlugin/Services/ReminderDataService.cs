using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderDataService
	{
		public ReminderDataService ()
		{
		}
		public async Task<List<Reminder>> GetReminders(){

			await Task.Delay (TimeSpan.FromSeconds (3));
			return	new List<Reminder> {
				new Reminder{Name = "Blood Sugar Monitoring", Description="Any description can be there", isActive=false},
				new Reminder{Name = "Medicine 500 Mg", Description="Any description can be there", isActive=true},
				new Reminder{Name = "Emergency Work", Description="Any description can be there", isActive=true},
				new Reminder{Name = "Emergency Training", Description="Any description can be there", isActive=false},
			};

		}
	}
}

