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

namespace ESPDroid.Activities
{
    public class SensorFragment : Fragment
    {
        public PlotModel plotModel;
        private bool loop = false;
        private int i = 0;
        private LineSeries series;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //while(loop)
            //{
            //    double y = Convert.ToDouble(HtmlValues.htmlValue[0]);
            //    addPlotModelSeries(i, y);
            //    updatePlotModel(series);
            //}
        }

        private PlotModel CreatePlotModel()
        {
            plotModel = new PlotModel { Title = "Graph" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series.Points.Add(new DataPoint(0.0, 6.0));
            series.Points.Add(new DataPoint(1.4, 2.1));
            series.Points.Add(new DataPoint(2.0, 4.2));
            series.Points.Add(new DataPoint(3.3, 2.3));
            series.Points.Add(new DataPoint(4.7, 7.4));
            series.Points.Add(new DataPoint(6.0, 6.2));
            series.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series);
            return plotModel;
        }

        public void addPlotModelSeries(double x, double y)
        {
            series = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series.Points.Add(new DataPoint(x, y));
        }

        public void updatePlotModel(LineSeries series_)
        {
            plotModel.Series.Add(series_);
        }

        public void clearPlotModel()
        {
            plotModel.Series.Clear();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragment_tab_sensors, container, false);

            PlotView plotView = view.FindViewById<PlotView>(Resource.Id.plotview1);
            plotView.Model = CreatePlotModel();

            return view;
        }
    }
}