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

		public List<string> featureList { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }
		Reminder r = new Reminder ();
		public string Name {
			get{ 
				return r.Name;
			}
			set{ 
				r.Name = value;			
			}
		}

		public string Description {
			get{ 
				return r.Description;
			}
			set{
				r.Description = value;
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

				// tmp has string from selection...
				var tmp = featureList [_index];
				//OnPropertyChanged("SelectIndex");
			}
		}

		//presetting the picker time and date
		public void preSetFields()
		{
			Time = DateTime.Now.TimeOfDay;
			Date = DateTime.Now;
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


