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

        private CheckBox c1;
        private CheckBox c2;
        private CheckBox c3;
        private CheckBox c4;
        private CheckBox c5;
        private CheckBox c6;
        private CheckBox c7;
        private CheckBox c8;

        private int i = 0;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            i = 0;
        }

        private void updateValues()
        {
            Looper.Prepare();
            while(true)
            {
                Application.SynchronizationContext.Post(_ => {
                    s1.Text = HtmlValues.sensor1;
                    s2.Text = HtmlValues.sensor2;
                    s3.Text = HtmlValues.sensor3;
                    s4.Text = HtmlValues.sensor4;
                    s5.Text = HtmlValues.sensor5;
                    s6.Text = HtmlValues.sensor6;
                    s7.Text = HtmlValues.sensor7;
                    s8.Text = HtmlValues.sensor8;

                    updatePlotModel(0, i, Convert.ToDouble(HtmlValues.sensor1));
                    updatePlotModel(1, i, Convert.ToDouble(HtmlValues.sensor2));
                    updatePlotModel(2, i, Convert.ToDouble(HtmlValues.sensor3));
                    updatePlotModel(3, i, Convert.ToDouble(HtmlValues.sensor4));
                    updatePlotModel(4, i, Convert.ToDouble(HtmlValues.sensor5));
                    updatePlotModel(5, i, Convert.ToDouble(HtmlValues.sensor6));
                    updatePlotModel(6, i, Convert.ToDouble(HtmlValues.sensor7));
                    updatePlotModel(7, i, Convert.ToDouble(HtmlValues.sensor8));

                    Console.WriteLine("working");
                }, null);

                if(i >= 10)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                Thread.Sleep(5000);
            }
        }

        private PlotModel CreatePlotModel()
        {
            plotModel = new PlotModel { Title = "Graph" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Maximum = 10, Minimum = 0, Title = "Time" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 100, Minimum = 0, Title = "Temp" });

            return plotModel;
        }

        public void addPlotModelSeries(int foo)
        {
            for(int i = 0; i <= foo; i++)
            {
                plotModel.Series.Add(new LineSeries());
            }
        }

        private void changePlotAppearance(int series, OxyColor colour, MarkerType marker, double size)
        {
            (plotModel.Series[series] as LineSeries).MarkerType = marker;
            (plotModel.Series[series] as LineSeries).MarkerSize = size;
            (plotModel.Series[series] as LineSeries).MarkerStroke = colour;
        }

        public void updatePlotModel(int series, double x, double y)
        {
            if ((plotModel.Series[series] as LineSeries).Points.Count > 8)
            {
                (plotModel.Series[series] as LineSeries).Points.RemoveAt(0);
            }

            (plotModel.Series[series] as LineSeries).Points.Add(new DataPoint(x, y));
            plotModel.InvalidatePlot(true);
        }

        public void clearPlotModel()
        {
            plotModel.Series.Clear();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_tab_sensors, container, false);

            c1 = view.FindViewById<CheckBox>(Resource.Id.chkBx1);
            c2 = view.FindViewById<CheckBox>(Resource.Id.chkBx2);
            c3 = view.FindViewById<CheckBox>(Resource.Id.chkBx3);
            c4 = view.FindViewById<CheckBox>(Resource.Id.chkBx4);
            c5 = view.FindViewById<CheckBox>(Resource.Id.chkBx5);
            c6 = view.FindViewById<CheckBox>(Resource.Id.chkBx6);
            c7 = view.FindViewById<CheckBox>(Resource.Id.chkBx7);
            c8 = view.FindViewById<CheckBox>(Resource.Id.chkBx8);

            plotView = view.FindViewById<PlotView>(Resource.Id.plotview1);
            plotView.Model = CreatePlotModel();

            s1 = view.FindViewById<TextView>(Resource.Id.txtv1);
            s2 = view.FindViewById<TextView>(Resource.Id.txtv2);
            s3 = view.FindViewById<TextView>(Resource.Id.txtv3);
            s4 = view.FindViewById<TextView>(Resource.Id.txtv4);
            s5 = view.FindViewById<TextView>(Resource.Id.txtv5);
            s6 = view.FindViewById<TextView>(Resource.Id.txtv6);
            s7 = view.FindViewById<TextView>(Resource.Id.txtv7);
            s8 = view.FindViewById<TextView>(Resource.Id.txtv8);

            s1.Text = "0";
            s2.Text = "0";
            s3.Text = "0";
            s4.Text = "0";
            s5.Text = "0";
            s6.Text = "0";
            s7.Text = "0";
            s8.Text = "0";

            addPlotModelSeries(8);

            changePlotAppearance(0, OxyColor.FromRgb(255, 0, 0), MarkerType.Circle, 4);
            changePlotAppearance(1, OxyColor.FromRgb(0, 255, 0), MarkerType.Circle, 4);
            changePlotAppearance(2, OxyColor.FromRgb(0, 255, 255), MarkerType.Circle, 4);
            changePlotAppearance(3, OxyColor.FromRgb(255, 122, 255), MarkerType.Circle, 4);
            changePlotAppearance(4, OxyColor.FromRgb(255, 0, 255), MarkerType.Circle, 4);
            changePlotAppearance(5, OxyColor.FromRgb(255, 255, 0), MarkerType.Circle, 4);
            changePlotAppearance(6, OxyColor.FromRgb(0, 0, 122), MarkerType.Circle, 4);
            changePlotAppearance(7, OxyColor.FromRgb(0, 122, 0), MarkerType.Circle, 4);

            ThreadPool.QueueUserWorkItem(o => runHtml.Start());
            ThreadPool.QueueUserWorkItem(o => updateValues());

            //

            c1.Click += (sender, args) =>
            {
                if((plotModel.Series[0] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[0] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[0] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c2.Click += (sender, args) =>
            {
                if ((plotModel.Series[1] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[1] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[1] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c3.Click += (sender, args) =>
            {
                if ((plotModel.Series[2] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[2] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[2] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c4.Click += (sender, args) =>
            {
                if ((plotModel.Series[3] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[3] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[3] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c5.Click += (sender, args) =>
            {
                if ((plotModel.Series[4] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[4] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[4] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c6.Click += (sender, args) =>
            {
                if ((plotModel.Series[5] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[5] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[5] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c7.Click += (sender, args) =>
            {
                if ((plotModel.Series[6] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[6] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[6] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            c8.Click += (sender, args) =>
            {
                if ((plotModel.Series[7] as LineSeries).IsVisible == false)
                {
                    (plotModel.Series[7] as LineSeries).IsVisible = true;
                }
                else
                {
                    (plotModel.Series[7] as LineSeries).IsVisible = false;
                }
                plotModel.InvalidatePlot(true);
            };

            return view;
        }
    }
}