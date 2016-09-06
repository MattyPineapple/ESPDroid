using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using ESPDroid.Classes;
using System.Text.RegularExpressions;

namespace ESPDroid.Activities
{
    public class HomeFragment : Fragment
    {
        private Button btnSave;
        private EditText url;
        private EditText port;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_tab_home, container, false);

            var introOne = view.FindViewById<TextView>(Resource.Id.txtIntroOne);
            var introTwo = view.FindViewById<TextView>(Resource.Id.txtIntroTwo);

            url = view.FindViewById<EditText>(Resource.Id.txtIP);
            port = view.FindViewById<EditText>(Resource.Id.txtPort);

            btnSave = view.FindViewById<Button>(Resource.Id.btnSave);

            introOne.Text = GetString(Resource.String.IntroOne);
            introTwo.Text = GetString(Resource.String.IntroTwo);

            btnSave.Click += (sender, args) =>
            {
                string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
                Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                string uri = url.Text.ToString();
                string prt = port.Text.ToString();

                if(reg.IsMatch(uri))
                {
                    int n;
                    HtmlValues.htmlURL = url.Text.ToString();

                    if(prt == null)
                    {
                        HtmlValues.needPort = false;

                        if (int.TryParse(prt, out n))
                        {
                            HtmlValues.htmlPort = port.Text.ToString();
                            Toast.MakeText(this.Activity, "Saved", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this.Activity, "Failed, incorrect input!", ToastLength.Short).Show();
                        }
                    }
                    else
                    {
                        if (int.TryParse(prt, out n))
                        {
                            HtmlValues.htmlPort = port.Text.ToString();
                            Toast.MakeText(this.Activity, "Saved", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this.Activity, "Failed, incorrect input!", ToastLength.Short).Show();
                        }
                    }
                }
                else
                {
                    Toast.MakeText(this.Activity, "Failed, incorrect input!", ToastLength.Short).Show();
                }             
            };

            return view;
        }
    }
}