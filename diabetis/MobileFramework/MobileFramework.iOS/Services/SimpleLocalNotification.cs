using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Foundation;
using UIKit;

using MobileFramework.iOS.Services;
using MobileFramework.Helpers.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SimpleLocalNotification))]
namespace MobileFramework.iOS.Services
{
    public class SimpleLocalNotification : ILocalNotifications
    {
        public void SendLocalNotification(string title, string description, int iconID, List<string> entrys, string name)
        {
            //---- when the add 1 minute notification is clicked, add a notification that fires
            // 1 second from now

            //---- create the notification
            UILocalNotification notification = new UILocalNotification();

            //---- set the fire date (the date time in which it will fire)
            var fireDate = DateTime.Now.AddSeconds(1);
            notification.FireDate = (NSDate)fireDate;

            //---- configure the alert stuff
            notification.AlertAction = description;
            notification.AlertBody = entrys.ToString();

            //---- modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            //---- set the sound to be the default sound
            notification.SoundName = UILocalNotification.DefaultSoundName;

            //				notification.UserInfo = new NSDictionary();
            //				notification.UserInfo[new NSString("Message")] = new NSString("Your 1 minute notification has fired!");

            //---- schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}
