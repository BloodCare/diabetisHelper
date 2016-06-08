using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using MobileFramework.PluginManager;
using System.Diagnostics;
using FreshMvvm;
using System.Windows.Input;

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

		public ReminderAddPageModel (){
		}


		public string Name
		{
			get { return _rName; }
			set { 
				_rName = value;
				if(_rName.Length>25)
					_rName = value.Substring(0,25); 
				//_rName = value;
				Debug.WriteLine (_rName);}
		}

		public string Description {
			get{ 
				return _rDescription;
			}
			set{
				_rDescription = value;
				if(_rDescription.Length>50)
					_rDescription = value.Substring(0,50); 
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

		public DateTime Date { get { return _Date;} set{ _Date = value; } }

		public TimeSpan Time { get{ return _Time;} set{_Time = value;} }


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
				return new Command( (value) =>
					{
						//_rName=r.Name;
						CoreMethods.PopToRoot(true);
						//_selFeature = featureList[_index];
						//Debug.WriteLine(_selFeature);
						//Debug.WriteLine(_selFeature);

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

