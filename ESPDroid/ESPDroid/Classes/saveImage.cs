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

using OxyPlot;
using OxyPlot.Xamarin.Android;

namespace ESPDroid.Classes
{
    class saveImage
    {
        public static void WriteToFile(string filePath, PlotModel plotModel)
        {
            //var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            //pngExporter.ExportToFile(plotModel, filePath);
        }
    }
}