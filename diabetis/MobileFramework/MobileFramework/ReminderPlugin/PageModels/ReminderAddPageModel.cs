using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using FreshMvvm;
using Acr.UserDialogs;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderAddPageModel : FreshBasePageModel
	{

		String _rName = string.Empty;
		String _rDescription = string.Empty;
		String _selFeature = string.Empty;
		public List<string> featureList = new List<string>();
		DateTime _Date;
		TimeSpan _Time;
		DateTime _rDateTime;
		string pluginName = "ReminderPlugin";
		Reminder _newReminder;
		ReminderDataService rds;
		IUserDialogs _userDialog;


		public ReminderAddPageModel(IUserDialogs userDialogs)
		{
			rds = ReminderDataService.ReminderDataServ;
			_userDialog =  userDialogs;
			_Date = DateTime.Now;
			_Time = _Date - _Date.Date;
		}


		public string Name
		{
			get { return _rName; }
			set
			{
				_rName = value;
				if (_rName.Length > 40)
					_rName = value.Substring(0, 40);
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
				if (_rDescription.Length > 150)
					_rDescription = value.Substring(0, 150);
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
			//_Time = DateTime.Now.TimeOfDay;

			_Date = DateTime.Now;
			_Time = _Date - _Date.Date;
		}



		//
		public Command saveReminder
		{
			get
			{
				return new Command((value) =>
				   {

					   var reminder = CreateNewReminder();
					   
						//Constructing a dateTime variable for user selected date and times
					   _rDateTime = new DateTime(_Date.Year, _Date.Month, _Date.Day, _Time.Hours, _Time.Minutes, _Time.Seconds);
					   _selFeature = featureList[_index];
					   //if clause with isvalidateDateTime method to notify the user with toast and stay on screen,
					   // else let it save and poptoroot
					   if (isvalidateDateTime(_rDateTime))
					    // _userDialog.ShowError("Please choose proper Date and Time", 2000);
						_userDialog.ErrorToast("Please choose proper Date and Time", null, 2000);
					else {
							_userDialog.ShowSuccess("Reminder Added", 2000);
						//_userDialog.SuccessToast("Reminder Added", null, 2000);
							rds.AddReminder(reminder);
						   	setreminder(_rName, _rDescription, _selFeature, _rDateTime);
						   	CoreMethods.PopToRoot(true);
					}

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

		// To check whether user selected date time are in future.
		public bool isvalidateDateTime(DateTime dt) {

			var _dt = dt;
			if (_dt < _Date)
				return true;
			else
				return false;
		}


		// method for setting local notifications
		public void setreminder(string name, string description, string feature, DateTime datetime)
		{

			//var remiderService = DependencyService.Get<ILocalNotifications>();
			var reminderService2 = DependencyService.Get<IReminderService>();

			// send user set date and time in the function.
			//remiderService.SendReminderNotification(name, description,datetime, pluginName );
			reminderService2.RemindNormal(datetime, name, description, feature);
		}

	}
}

