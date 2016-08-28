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

namespace ESPDroid.Activities
{
    public class InfoFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_tab_info, container, false);

            var about = view.FindViewById<TextView>(Resource.Id.txtAboutText);
            var help = view.FindViewById<TextView>(Resource.Id.txtHelpText);
            var credits = view.FindViewById<TextView>(Resource.Id.txtCreditsText);
            var specialThanks = view.FindViewById<TextView>(Resource.Id.txtSpecialThanksText);

            about.Text = GetString(Resource.String.about);
            help.Text = GetString(Resource.String.help);
            credits.Text = GetString(Resource.String.credits);
            specialThanks.Text = GetString(Resource.String.specialThanks);

            return view;
        }
    }
}