using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MobileFramework.ReminderPlugin
{
	public interface IReminderDataService
	{
		Task<List<Reminder>> GetReminders();

	}
}

