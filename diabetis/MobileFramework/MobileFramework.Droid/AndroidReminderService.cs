using Android.Support.V4.App;
using Android.Content;
using Android.App;
using Xamarin.Forms;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Java.Util;
using MobileFramework.Droid;
using System;
using MobileFramework.ReminderPlugin;

[assembly: Dependency(typeof(AndroidReminderService))]

namespace MobileFramework.Droid
{
	public class AndroidReminderService : Activity, IReminderService 
	{
		#region IReminderService implementation
		public void Remind (String name, String description, DateTime date, TimeSpan time)
		{
			//throw new System.NotImplementedException ();

			int day = date.Day;
			int year = date.Year;
			int month = date.Month;
			int hr = time.Hours;
			int min = time.Minutes;

			ContentValues eventValues = new ContentValues();

			eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId,
				1);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
				name);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
				description);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
				GetDateTimeMS(year, month, day, hr, min));
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
				GetDateTimeMS(year, month, day, hr, min));

			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
				"UTC");
			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
				"UTC");
			var context = Xamarin.Forms.Forms.Context as Activity;

			var uri = context.ContentResolver.Insert(CalendarContract.Events.ContentUri,
				eventValues);

		}
		#endregion
		long GetDateTimeMS(int yr, int month, int day, int hr, int min)
		{
			//Calendar c = Calendar.GetInstance(Java.Util.TimeZone.GetTimeZone("UTC"));
			Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

			c.Set(Calendar.DayOfMonth, day);
			c.Set(Calendar.HourOfDay, hr);
			c.Set(Calendar.Minute, min);
			c.Set(Calendar.Month, month - 1);
			c.Set(Calendar.Year, yr);

			return c.TimeInMillis;
		}
	}
}
