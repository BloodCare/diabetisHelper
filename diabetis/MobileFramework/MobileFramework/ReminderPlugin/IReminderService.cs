using System;

namespace MobileFramework.ReminderPlugin
{
	public interface IReminderService
	{
		void Remind(String name, String description, DateTime date, TimeSpan time);
		void RemindNormal(DateTime dateTime, string title, string message, string feature);
	}
}
