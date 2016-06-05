using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using MobileFramework.PluginManager;
using System.Collections.ObjectModel;

namespace MobileFramework.ReminderPlugin
{

    public class ReminderListPageModel : FreshMvvm.FreshBasePageModel
    {
        //IReminderDataService _reminderDataService;
        ReminderDataService _reminderDataService;

        public ReminderListPageModel(/*IReminderDataService reminderDataService */ )
        {
            ReminderDataService reminderDataService = ReminderDataService.ReminderDataServ; //new ReminderDataService ();
            _reminderDataService = reminderDataService;
        }

        public ObservableCollection<Reminder> ReminderList
        {
            get; set;
        }

        public override async void Init(object initData)
        {
            base.Init(initData);
            var rm = await _reminderDataService.GetReminders();
            ReminderList = new ObservableCollection<Reminder>(rm);
        }
        public async void ReloadReminders()
        {
            List<Reminder> rm = await _reminderDataService.GetReminders();
            ReminderList = new ObservableCollection<Reminder>(rm);
        }
        public Reminder SelectedReminder
        {
            get { return null; }
            set
            {
                CoreMethods.PushPageModel<ReminderPageModel>(value);
                RaisePropertyChanged();
            }
        }
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
        }


        public Command OnDelete
        {
            get
            {
                return new Command((value) =>
                {
                    var reminder = value as Reminder;
                    _reminderDataService.RemoveReminder(reminder);
                    this.ReloadReminders();
                });
            }
        }
        public Command AddReminder
        {
            get
            {
                return new Command((value) =>
                {
                    CoreMethods.PushPageModel<ReminderAddPageModel>(value);
                });
            }
        }

        public Command AddReminderToCalender
        {
            get
            {
                return new Command((value) =>
                {
                    CoreMethods.PushPageModel<ReminderToCalenderPageModel>(value);
                });
            }
        }

    }

}

