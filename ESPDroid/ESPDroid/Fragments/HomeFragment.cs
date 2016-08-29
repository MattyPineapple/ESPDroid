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

namespace ESPDroid.Activities
{
    public class HomeFragment : Fragment
    {
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
            introOne.Text = GetString(Resource.String.IntroOne);
            introTwo.Text = GetString(Resource.String.IntroTwo);
            return view;
        }
    }
}