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

namespace ESPDroid.Classes
{
    class HtmlValues
    {
        public static List<string> htmlValue = new List<string>();

        public static string htmlURL { get; set; }
        public static string htmlPort { get; set; }

        public static bool needPort { get; set; }

        public static string sensor1 { get; set; }
        public static string sensor2 { get; set; }
        public static string sensor3 { get; set; }
        public static string sensor4 { get; set; }
        public static string sensor5 { get; set; }
        public static string sensor6 { get; set; }
        public static string sensor7 { get; set; }
        public static string sensor8 { get; set; }

        public static bool relay1 { get; set; }
        public static bool relay2 { get; set; }
        public static bool relay3 { get; set; }
        public static bool relay4 { get; set; }
        public static bool relay5 { get; set; }
        public static bool relay6 { get; set; }
        public static bool relay7 { get; set; }
        public static bool relay8 { get; set; }
    }
}