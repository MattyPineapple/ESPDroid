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

            //btnSave.Click += delegate {
            //    HtmlValues.htmlURL = url.ToString();
            //    HtmlValues.htmlPort = port.ToString();
            //};
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

            return view;
        }
    }
}