using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Xamarin.Forms;
using MobileFramework.PluginManager;

using MobileFramework.Droid.Services;
using MobileFramework.Helpers.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SimpleLocalNotification))]
namespace MobileFramework.Droid.Services
{
    [Activity(Label = "MobileFramework", Icon = "@drawable/icon")]
    public class SimpleLocalNotification : Activity , ILocalNotifications
    {
        public SimpleLocalNotification()
        {

        }
        /// <summary>
        /// native android implementation to send notifications
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="iconID"></param>
        /// <param name="entrys"></param>
        /// <param name="pluginName"></param>
        public void SendLocalNotification(string title, string description, int iconID, List<string> entrys, string pluginName)
        {

            var context = Xamarin.Forms.Forms.Context;

            var manager =
     (NotificationManager)context.GetSystemService(Context.NotificationService) as NotificationManager;

            var intent =
                context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
            intent.PutExtra("PluginName", pluginName);

            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.CancelCurrent);


            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(Android.App.Application.Context)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(description)
                .SetSmallIcon(Resource.Drawable.icon);

            // Instantiate the Inbox style:
            Notification.InboxStyle inboxStyle = new Notification.InboxStyle();

            entrys.ForEach(x => inboxStyle.AddLine(x));

            // Generate a message summary for the body of the notification:
            //inboxStyle.SetSummaryText("+2 more");

            // Plug this style into the builder:
            builder.SetStyle(inboxStyle);

            // Build the notification:
            Notification notification = builder.Build();

     

            // Publish the notification:
            const int notificationId = 0;
            manager.Notify(0, notification);
        }       
    }
}