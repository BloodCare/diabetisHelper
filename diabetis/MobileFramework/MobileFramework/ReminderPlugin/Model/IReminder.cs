using System;

namespace MobileFramework.ReminderPlugin.Model
{
    public interface IReminder 
    {
        string Description { get; set; }
        bool Active { get; set; }
        string LinkToFeature { get; set; }
        string Name { get; set; }
        DateTime OnDate { get; set; }
    }
}