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
using System.Threading;

namespace ESPDroid.Classes
{
    class runHtml
    {
        private static bool loopHtml = false;

        public static void Start()
        {
            loopHtml = true;
            while (loopHtml)
            {
                GetHtml.FetchData();
                Thread.Sleep(5000);
            }
        }

        public static void Stop()
        {
            loopHtml = false;
        }

        public static bool checkSettings()
        {
            var returnStatus = GetHtml.FetchData();

            if (returnStatus == "Success")
            {
                return true;
            }
            else if (returnStatus == "Error")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}