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
using Android.Graphics;

namespace MobileFramework.Droid.Helpers
{
    class Segment
    {
        public Point innerPoint1
        {
            get; set;
        }
        public Point outerPoint1
        {
            get; set;
        }
        public Point innerPoint2
        {
            get; set;
        }
        public Point outerPoint2
        {
            get; set;
        }

        public Segment()
        {
            innerPoint1 = new Point();
            outerPoint1 = new Point();
            innerPoint2 = new Point();
            outerPoint2 = new Point();
        }
    }
}