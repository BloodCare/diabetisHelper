using System;
using System.Collections.Generic;
using System.ComponentModel;
using MobileFramework.PluginManager;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderToCalenderPageModel : FreshMvvm.FreshBasePageModel
	{
		public ReminderToCalenderPageModel ()
		{

		}

		String _rName = string.Empty;
		string _prName = string.Empty;
		String _rDescription = string.Empty;
		String _selFeature = string.Empty;
		public List<string> featureList = new List<string>();
		DateTime _Date = DateTime.Now;
		TimeSpan _Time;

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


		// method to obtain feature index and save the string in a tmp
		int _index;
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

		public DateTime Date { get { return _Date;} set{ _Date = value; } }

		public TimeSpan Time { get{ return _Time;} set{_Time = value;} }


		//presetting the picker time and date
		public void preSetFields()
		{
			_Time = DateTime.Now.TimeOfDay;
			_Date = DateTime.Now;
		}

		public Command saveCalReminder
		{
			get
			{
				//test notification
				return new Command( (value) =>
					{

						CoreMethods.PopToRoot(true);
					});
			}
		}



		public Command cancelCalReminder
		{
			get
			{
				//test notification
				return new Command( (value) =>
					{

						CoreMethods.PopToRoot(true);
					});
			}
		}
	}
}