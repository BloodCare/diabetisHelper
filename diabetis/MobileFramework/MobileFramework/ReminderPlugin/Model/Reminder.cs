using System;
using PropertyChanged;
using MobileFramework.Database;
using SQLite;

namespace MobileFramework.ReminderPlugin
{
    [ImplementPropertyChanged]
    public class Reminder : BusinessEntityBase
    {
        public Reminder()
        {
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
        public string LinkToFeature { get; set; } = string.Empty;
        public DateTime OnDate { get; set; } = DateTime.UtcNow;
        [Ignore]
        public string CreatedDisplay
        {
            get
            {
                return OnDate.ToLocalTime().ToString("f");
            }
        }

    }
}

