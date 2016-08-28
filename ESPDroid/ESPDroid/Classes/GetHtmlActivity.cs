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

using System.Net;
using System.IO;

using HtmlAgilityPack;

namespace ESPDroid.Classes
{
    [Activity(Label = "GetHtmlActivity")]
    public class GetHtmlActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        public static string FetchData()
        {
            WebResponse responseStats = null;
            WebRequest requestStats = WebRequest.Create(HtmlValues.htmlURL + ":" + HtmlValues.htmlPort);

            try { responseStats = requestStats.GetResponse(); }
            catch { return "Error"; }

            StreamReader srResponse = new StreamReader(responseStats.GetResponseStream(), Encoding.UTF8);
            string htmlResponse = srResponse.ReadToEnd();
            srResponse.Close();
            responseStats.Close();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlResponse);

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//arduino"))
            {
                foreach (HtmlNode node2 in node.SelectNodes(".//sensor[@id]"))
                {
                    string attributeValue = node2.GetAttributeValue("id", "");
                    switch (attributeValue)
                    {
                        case "1":
                            HtmlValues.htmlValue.Add("1:" + node2.InnerText);
                            break;
                        case "2":
                            HtmlValues.htmlValue.Add("2:" + node2.InnerText);
                            break;
                        case "3":
                            HtmlValues.htmlValue.Add("3:" + node2.InnerText);
                            break;
                        case "4":
                            HtmlValues.htmlValue.Add("4:" + node2.InnerText);
                            break;
                        case "5":
                            HtmlValues.htmlValue.Add("5:" + node2.InnerText);
                            break;
                        case "6":
                            HtmlValues.htmlValue.Add("6:" + node2.InnerText);
                            break;
                        case "7":
                            HtmlValues.htmlValue.Add("7:" + node2.InnerText);
                            break;
                        case "8":
                            HtmlValues.htmlValue.Add("8:" + node2.InnerText);
                            break;
                    }
                }
            }

            updateHtmlValues();
            return "Success";
        }

        public static void updateHtmlValues()
        {
            string s1 = HtmlValues.htmlValue[0];
            HtmlValues.sensor1 = s1.Split(':')[1];

            string s2 = HtmlValues.htmlValue[1];
            HtmlValues.sensor2 = s2.Split(':')[1];

            string s3 = HtmlValues.htmlValue[2];
            HtmlValues.sensor3 = s3.Split(':')[1];

            string s4 = HtmlValues.htmlValue[3];
            HtmlValues.sensor4 = s4.Split(':')[1];

            string s5 = HtmlValues.htmlValue[4];
            HtmlValues.sensor5 = s5.Split(':')[1];

            string s6 = HtmlValues.htmlValue[5];
            HtmlValues.sensor6 = s6.Split(':')[1];

            string s7 = HtmlValues.htmlValue[6];
            HtmlValues.sensor7 = s7.Split(':')[1];

            string s8 = HtmlValues.htmlValue[7];
            HtmlValues.sensor8 = s8.Split(':')[1];
        }
    }
}