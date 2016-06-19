using System;
using System.Collections.Generic;
using System.ComponentModel;
using Acr.UserDialogs;
using MobileFramework.PluginManager;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderToCalenderPageModel : FreshMvvm.FreshBasePageModel
	{
		public ReminderToCalenderPageModel (IUserDialogs userDialogs)
		{
			_userDialog = userDialogs;
			_Date = DateTime.Now;
			_Time = _Date - _Date.Date;
		}

		String _rName = string.Empty;
		String _rDescription = string.Empty;
		DateTime _Date = DateTime.Now;
		TimeSpan _Time;
		IUserDialogs _userDialog;

		public string Name {
			get{ 
				return _rName;
			}
			set{ 
				_rName = value;			
			}
		}

		public string Description {
			get{ 
				return _rDescription;
			}
			set{
				_rDescription = value;
			}
		}

		public DateTime Date { get { return _Date;} set{ _Date = value; } }

		public TimeSpan Time { get{ return _Time;} set{_Time = value;} }


		/*//presetting the picker time and date
		public void preSetFields()
		{
			_Time = DateTime.Now.TimeOfDay;
			_Date = DateTime.Now;
		}*/

		public Command saveCalReminder
		{
			get
			{
				//test notification
				return new Command( (value) =>
					{
						if (isvalidateDateTime(_Date))
							_userDialog.ErrorToast("Please choose proper Date and Time", null, 2000);
						else {
							_userDialog.ShowSuccess("Event Added in Calendar", 2000);
							setAppointment(_rName, _rDescription, _Date, _Time);
							CoreMethods.PopToRoot(true);
						}
						//CoreMethods.PopToRoot(true);
					});
			}
		}

		// To check whether user selected date time are in future.
		public bool isvalidateDateTime(DateTime dt)
		{

			var _dt = dt;
			var chkDt = DateTime.Now;
			if (_dt < chkDt)
				return true;
			else
				return false;
		}


		public Command cancelCalReminder
		{
			get
			{
				
				return new Command( (value) =>
					{

						CoreMethods.PopToRoot(true);
					});
			}
		}

		// method for setting calendar events
		public void setAppointment(String name, String description, DateTime date, TimeSpan time)
		{
			var appointmentService = DependencyService.Get<IReminderService>();

			// send user set date and time in the Dependency Serice.
			appointmentService.Remind(name, description, date, time);
		}

	}
}