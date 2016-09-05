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

using OxyPlot;
using OxyPlot.Xamarin.Android;
using OxyPlot.Axes;
using OxyPlot.Series;

using ESPDroid.Classes;
using System.Threading;

namespace ESPDroid.Activities
{
    public class SensorFragment : Fragment
    {
        private PlotModel plotModel;
        private PlotView plotView;

        private TextView s1;
        private TextView s2;
        private TextView s3;
        private TextView s4;
        private TextView s5;
        private TextView s6;
        private TextView s7;
        private TextView s8;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ThreadPool.QueueUserWorkItem(o => runHtml.Start());
        }

        private PlotModel CreatePlotModel()
        {
            plotModel = new PlotModel { Title = "Graph" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Maximum = 20, Minimum = 0 });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            plotModel.Series.Add(new LineSeries());

            return plotModel;
        }

        public void addPlotModelSeries(double x, double y)
        {
            plotModel.Series.Add(new LineSeries());
            
        }

        public void updatePlotModel(double x, double y, int series)
        {
            (plotModel.Series[series] as LineSeries).Points.Add(new DataPoint(x, y));
        }

        public void clearPlotModel()
        {
            plotModel.Series.Clear();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_tab_sensors, container, false);

            plotView = view.FindViewById<PlotView>(Resource.Id.plotview1);
            plotView.Model = CreatePlotModel();

            s1 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s2 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s3 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s4 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s5 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s6 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s7 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s8 = view.FindViewById<TextView>(Resource.Id.txtv1);

            s1.Text = "0";
            s2.Text = "0";
            s3.Text = "0";
            s4.Text = "0";
            s5.Text = "0";
            s6.Text = "0";
            s7.Text = "0";
            s8.Text = "0";

            return view;
        }
    }
}