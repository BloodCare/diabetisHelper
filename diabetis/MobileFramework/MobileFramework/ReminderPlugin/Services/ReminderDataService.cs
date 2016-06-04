using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MobileFramework.ReminderPlugin
{
    public class ReminderDataService : IReminderDataService
    {
        private static List<Reminder> _reminderList;
        private static ReminderDataService _reminderDataServ;

        private ReminderDataService()
        {
            _reminderList = new List<Reminder>();
            this.Initilize();
        }
        public void Initilize()
        {
            this.LoadReminders();
        }
        void LoadReminders()
        {
            AddReminder(new Reminder { Name = "Blood Sugar", Description = "Any description can be there", isActive = false });
            AddReminder(new Reminder { Name = "Medicine", Description = "Any description can be there", isActive = true });
            AddReminder(new Reminder { Name = "Emergency", Description = "Any description can be there", isActive = true });
            AddReminder(new Reminder { Name = "Physical", Description = "Any description can be there", isActive = false });
        }



        public static ReminderDataService ReminderDataServ
        {
            get
            {
                if (_reminderDataServ == null)
                    _reminderDataServ = new ReminderDataService();
                return _reminderDataServ;
            }
        }

        public bool AddReminder(Reminder reminder)
        {
            _reminderList.Add(reminder);
            return true;
        }

        public async Task<List<Reminder>> GetReminders()
        {

            await Task.Delay(TimeSpan.FromSeconds(0));
            return _reminderList;

        }

        public bool RemoveReminder(Reminder reminder)
        {
            _reminderList.Remove(reminder);
            return true;

        }
    }
}

