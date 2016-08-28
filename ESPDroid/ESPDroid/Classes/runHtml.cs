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
    class runHtml
    {
        private static bool loopHtml = false;

        public static void Start()
        {
            if(checkSettings())
            {
                loopHtml = true;
                while (loopHtml)
                {
                    try
                    {
                        GetHtml.FetchData();

                        //FragmentManager fm = getSupportFragmentManager();

                        ////if you added fragment via layout xml
                        //YourFragmentClass fragment = (YourFragmentClass)fm.findFragmentById(R.id.your_fragment_id);
                        //fragment.yourPublicMethod();
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

            if (returnStatus == "Success") {
                return true;
            } else if(returnStatus == "Error") {
                return false;
            } else {
                return false;
            }
        }
    }
}