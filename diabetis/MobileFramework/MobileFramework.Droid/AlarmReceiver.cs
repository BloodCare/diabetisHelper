using System;
using Android.Content;
using Android.App;
using Android.Support.V4.App;
using Android.Graphics;

namespace MobileFramework.Droid
{
	[BroadcastReceiver]
	public class AlarmReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{

			var message = intent.GetStringExtra("message");
			var title = intent.GetStringExtra("title");
			var feature = intent.GetStringExtra("feature");

			var notIntent = new Intent(context, typeof(MainActivity));
			var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.UpdateCurrent);


			var manager = (NotificationManager)context.GetSystemService(Context.NotificationService) as NotificationManager;

			// Instantiate the Big Text style:
			Notification.BigTextStyle textStyle = new Notification.BigTextStyle();

			// Message to Display
			textStyle.BigText(message);

			// Set the summary text as feature label
			textStyle.SetSummaryText(feature);


			// Instantiate the builder and set notification elements:
			Notification.Builder builder = new Notification.Builder(Android.App.Application.Context)
				.SetContentIntent(contentIntent)
				.SetContentTitle(title)
				//.SetContentText(message)
				.SetSmallIcon(Resource.Drawable.icon)
				.SetDefaults(NotificationDefaults.Sound)
				.SetShowWhen(true)
				.SetAutoCancel(true)
				.SetStyle(textStyle);


			// Build the notification:
			Notification notification = builder.Build();

			// Publish the notification:
			const int notificationId = 0;
			manager.Notify(0, notification);
		}
	}
}

