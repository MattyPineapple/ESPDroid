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

using ESPDroid.Activities;

namespace ESPDroid
{
    [Activity(Label = "ESPDroid", MainLauncher = false)]
    public class TabActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);

            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Home", new HomeFragment());
            AddTab("Sensors", new SensorFragment());
            AddTab("Relays", new RelayFragment());
            AddTab("Info", new InfoFragment());
        }

        void AddTab(string tabText, Fragment fragment)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabText);
            
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) 
            {
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            ActionBar.AddTab(tab);
        }
    }
}