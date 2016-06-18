using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileFramework.Database;
namespace MobileFramework.ReminderPlugin
{
    public class ReminderDataService : IReminderDataService
    {
        private static List<Reminder> _reminderList;
        private static ReminderDataService _reminderDataServ;
        private BloodCareDatabase _bloodCareDatabase;

        private ReminderDataService()
        {
            _reminderList = new List<Reminder>();
            _bloodCareDatabase = new BloodCareDatabase();
            this.Initilize();
        }
        public void Initilize()
        {
            this.LoadReminders();
        }
        void LoadReminders()
        {
            _reminderList.Clear();
            foreach (var item in _bloodCareDatabase.GetItems<Reminder>())
            {
                _reminderList.Add(item);
            }
           
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
            _bloodCareDatabase.SaveItem(reminder);
            LoadReminders();
            return true;
        }

        public async Task<List<Reminder>> GetReminders()
        {

            await Task.Delay(TimeSpan.FromSeconds(0));
            return _reminderList;

        }

        public bool RemoveReminder(Reminder reminder)
        {
            _bloodCareDatabase.DeleteItem(reminder);
            LoadReminders();
            return true;

        }
    }
}

