using MobileFramework.PluginManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	/// <summary>
	/// the entry point of the alarmplugin, which will be called from navigation in master detail view
	/// </summary>
	public partial class ReminderPluginPage : ContentPage
	{
		private ReminderPluginPageModel model;
		public ReminderPluginPage()
		{
			InitializeComponent();
			// var test = Activator.CreateInstance((from KeyValuePair<String, Type> tmp in PluginCollector.Instance.Plugins where tmp.Key == "AlarmPlugin" select tmp.Value).FirstOrDefault());
		}


		/// <summary>
		/// set up the eventlistener to act when the station list in PageModel changed
		/// gets the PageModel
		/// </summary>
		protected  override void OnAppearing()
		{
			model = (ReminderPluginPageModel)this.BindingContext;

		}



		/// <summary>
		/// unsubscibes the property changed event when view is closed
		/// </summary>
		protected override void OnDisappearing()
		{

		}



	}
}
