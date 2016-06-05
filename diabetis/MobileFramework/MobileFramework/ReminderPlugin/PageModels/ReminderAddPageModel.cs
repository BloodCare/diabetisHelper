using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using MobileFramework.PluginManager;
using System.Diagnostics;
using FreshMvvm;

namespace MobileFramework.ReminderPlugin
{
	public class ReminderAddPageModel : FreshBasePageModel
	{
		//public String _rName = string.Empty;
		//public String _rDescription = string.Empty;
		//public List<string> soundList {get; set;}
		//public string _feature { get; set;}
		public List<string> featureList { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }

		public ReminderAddPageModel ()
		{

		}

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



		/*string _displayText;

		public string DisplayText
		{ 
			get
			{
				return _displayText;
			}
			set
			{
				_displayText = value;
				OnPropertyChanged("DisplayText");
			}

		}
			
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var changed = PropertyChanged;
			if (changed != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}*/



		//
		public Command saveReminder
		{
			get
			{
				return new Command( (value) =>
					{
						//_rName=r.Name;
						CoreMethods.PopToRoot(true);
						//Debug.WriteLine(_rName);

					});
			}
		}

		public Command cancelReminder
		{
			get
			{
				return new Command( (value) =>
					{
						CoreMethods.PopToRoot(true);
					});
			}
		}

	}
}

