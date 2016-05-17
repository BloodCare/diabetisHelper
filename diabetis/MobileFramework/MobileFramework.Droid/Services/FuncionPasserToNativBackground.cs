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

namespace MobileFramework.Droid.Services
{
    public static class FunctionPasserToNativeBackground
    {
       
        public static string FunctionName { get; set; }

        public static List<object> Params { get; set; }

        public static object ClassObject { get; set; }

    }
}