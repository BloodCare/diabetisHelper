using System;
using Android.Support.V4.App;
using Android.Content;
using Android.App;
using Xamarin.Forms;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Java.Util;
using MobileFramework.Droid;
using MobileFramework.ReminderPlugin;
using Android.Media;
using System.Diagnostics;
using System.Collections.Generic;

[assembly: Dependency(typeof(AndroidRingtoneSelector))]
namespace MobileFramework.Droid
{
	[Activity()]
	public class AndroidRingtoneSelector : Activity, IAndroidRingtoneSelector
	{
		#region IAndroidRingtoneSelector implementation
		public void startRingtonePicker()
		{

			Intent intent = new Intent(RingtoneManager.ActionRingtonePicker);
			//intent.PutExtra();
			intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, RingtoneManager.GetDefaultUri(RingtoneType.All));
			//intent.AddFlags(ActivityFlags.SingleTop);
			//intent.PutExtra(RingtoneManager.ExtraRingtoneExistingUri, RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
			//intent.PutExtra(Android.Media.RingtoneManager.ExtraRingtoneDefaultUri);
			const int start = 100;
			((Activity)Forms.Context).StartActivityForResult(intent, start);
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			//if (requestCode == 40)
			//{
			//Ringtone ringTone;
			//Uri uri = data.getParcelableExtra(RingtoneManager.EXTRA_RINGTONE_PICKED_URI);
			//Uri uri = data.GetParcelableExtra(RingtoneManager.ExtraRingtonePickedUri);
			//ringTone = RingtoneManager.getRingtone(Xamarin.Forms.Forms.Context, uri);

			Android.Net.Uri ring = (Android.Net.Uri)data.GetParcelableExtra(RingtoneManager.ExtraRingtonePickedUri);
			System.Diagnostics.Debug.WriteLine(ring.ToString());
			//ringTone = RingtoneManager.GetRingtone(Xamarin.Forms.Forms.Context, uri)
			//Toast.makeText(MainActivity.this,
			//		ringTone.getTitle(MainActivity.this),
			//		Toast.LENGTH_LONG).show();
			//ringTone.play();

			//}
			//void ((Activity)Forms.Context).On(){ }

		}
		#endregion
	}
}

