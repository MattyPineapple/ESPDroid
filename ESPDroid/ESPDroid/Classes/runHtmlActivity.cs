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
    [Activity(Label = "runHtmlActivity")]
    public class runHtmlActivity : Activity
    {
        private static bool loopHtml = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        public static void Start()
        {
            if (checkSettings())
            {
                loopHtml = true;
                while (loopHtml)
                {
                    try
                    {
                        GetHtml.FetchData();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: {0}", e.Message);
                    }
                }
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