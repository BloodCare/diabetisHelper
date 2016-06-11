using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MobileFramework.ReminderPlugin
{
	public partial class ReminderListPage : ContentPage
	{
		public ReminderListPage ()
		{
			InitializeComponent ();
		}
        protected override void  OnAppearing()
        {
            var vm = this.BindingContext as ReminderListPageModel; 
            if (vm == null)
                return;

            //var itemsSource = vm.MyList;

            //if (!itemsSource.Any())
            //{
            //    // If the items source is empty, switch to the filter page
            //    await vm.RaiseFunction("CMD3");
            //    return;
            //}
            vm.ReloadReminders();
        }

    }
}

