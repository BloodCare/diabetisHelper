using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using MobileFramework.Helpers.Messages;
using MobileFramework.iOS.Services;
using MobileFramework.Model;

namespace MobileFramework.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // check for a notification
      
            if (options != null)
            {

                // check for a local notification
                if (options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
                {

                    UILocalNotification localNotification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
                    if (localNotification != null)
                    {

                        new UIAlertView(localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show();
                        // reset our badge
                        UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                    }
                }

                // check for a remote notification
                if (options.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
                {

                    NSDictionary remoteNotification = options[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;
                    if (remoteNotification != null)
                    {
                        //new UIAlertView(remoteNotification.AlertAction, remoteNotification.AlertBody, null, "OK", null).Show();
                    }
                }
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                                               UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                                           );

                app.RegisterUserNotificationSettings(notificationSettings);
                app.RegisterForRemoteNotifications();
            }
            else
            {
                //==== register for remote notifications and get the device token
                // set what kind of notification types we want
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
                // register for remote notifications
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }



            WireUpLongRunningTask();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(null));

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        ///
        /// </summary>
        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            new UIAlertView(notification.AlertAction, notification.AlertBody, null, "OK", null).Show();

            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }


        LongRunningTask longRunningTaskExample;
        void WireUpLongRunningTask()
        {
            MessagingCenter.Subscribe<StartLongRunningTaskMessage, FunctionPassingToNativeBackground>(this, "StartLongRunningTaskMessage", async (message, obj) =>
            {
                longRunningTaskExample = new LongRunningTask();
                await longRunningTaskExample.StartLongRunningTask(obj);
            });
        }
    }
}
