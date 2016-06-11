using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using MobileFramework.PluginManager;
using System.Diagnostics;
using FreshMvvm;
using System.Windows.Input;
using MobileFramework.Helpers.Services;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderAddPageModel : FreshBasePageModel
	{

		String _rName = string.Empty;
		string _prName = string.Empty;
		String _rDescription = string.Empty;
		String _selFeature = string.Empty;
		public List<string> featureList = new List<string>();
		DateTime _Date = DateTime.Now;
		TimeSpan _Time;
		DateTime _rDateTime;
		string pluginName = "ReminderPlugin";
		Reminder _newReminder;
		ReminderDataService rds;


		public ReminderAddPageModel()
		{
			rds = ReminderDataService.ReminderDataServ;
		}


		public string Name
		{
			get { return _rName; }
			set
			{
				_rName = value;
				if (_rName.Length > 25)
					_rName = value.Substring(0, 25);
				//_rName = value;
				Debug.WriteLine(_rName);
			}
		}

		Reminder CreateNewReminder()
		{
			_newReminder = new Reminder
			{
				Name = this.Name,
				Description = this.Description,
				OnDate = this.Date + this.Time,
				isActive = true


			};
			return _newReminder;
		}


		public string Description
		{
			get
			{
				return _rDescription;
			}
			set
			{
				_rDescription = value;
				if (_rDescription.Length > 50)
					_rDescription = value.Substring(0, 50);
			}
		}


		// method to obtain featurelist index
		int _index = 0;
		public int SelectIndex
		{
			get
			{
				return _index;
			}
			set
			{
				_index = value;

			}

		}

		public DateTime Date { get { return _Date; } set { _Date = value; } }

		public TimeSpan Time { get { return _Time; } set { _Time = value; } }


		//presetting the picker time and date
		public void preSetFields()
		{
			_Time = DateTime.Now.TimeOfDay;
			_Date = DateTime.Now;
		}



		//
		public Command saveReminder
		{
			get
			{
				return new Command((value) =>
				   {

					   var reminder = CreateNewReminder();
					   rds.AddReminder(reminder);
					   _rDateTime = new DateTime(_Date.Year, _Date.Month, _Date.Day, _Time.Hours, _Time.Minutes, _Time.Seconds);
					   setreminder(_rName, _rDescription, _rDateTime);
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

		// TODO: complete this method for setting local notifications
		public void setreminder(string name, string description, DateTime datetime)
		{

			var remiderService = DependencyService.Get<ILocalNotifications>();
			var reminderService2 = DependencyService.Get<IReminderService>();

			// send user set date and time in the function.
			//remiderService.SendReminderNotification(name, description,datetime, pluginName );
			reminderService2.RemindNormal(datetime, name, description);
		}

	}
}

