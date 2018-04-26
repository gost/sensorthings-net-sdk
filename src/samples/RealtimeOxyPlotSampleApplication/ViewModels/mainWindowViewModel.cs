using GraphWpfApplication;
using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using SensorThings.Client;
using SensorThings.Core;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using sensorthings.ODATA;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace OxyPlotDemo.ViewModels
{
    public class MainWindowModel
    {
        private static string serverurl = "https://gost.geodan.nl/v1.0";
        private static string datastreamid = "11";
        private static string server;
        private static string topic;
        private PlotModel plotModel;
        private PlotView plotview;

        public MainWindowModel(PlotView plotview)
        {
            this.plotview = plotview;
            server = new Uri(serverurl).Host;
            topic = $"Datastreams({datastreamid})/Observations";
            plotModel = new PlotModel();
            SetUpModel();
            LoadData();
            ConnectToMqtt();
        }

        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { plotModel = value; }
        }

        private void ConnectToMqtt()
        {
            var mqttclient = new MqttClient(server);
            byte code = mqttclient.Connect(Guid.NewGuid().ToString());

            ushort msgId = mqttclient.Subscribe(new string[] { topic },
                    new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            mqttclient.MqttMsgPublishReceived += ClientMqttMsgPublishReceived;
        }

        private async void LoadData()
        {
            var client = new SensorThingsClient(serverurl);
            var odata = new OdataQuery {
                QueryExpand = new QueryExpand(new[]
                    {
                        new Expand(new[] { "Observations" })
                    }
                )
            };
            

            var response = await client.GetDatastream(datastreamid, odata);
            var datastream = response.Result;

            var lineSerie = new OxyPlot.Series.LineSeries
            {
                StrokeThickness = 2,
                MarkerSize = 3,
                MarkerStroke = Colors.GetColors[0],
                MarkerType = MarkerTypes.markerTypes[0],
                CanTrackerInterpolatePoints = false,
                Title = datastream.Description,
                Smooth = false,
            };

            var obs = datastream.Observations.OrderBy(m => m.PhenomenonTime.Start);
            foreach (var observation in obs)
            {
                if(observation.PhenomenonTime != null)
                {
                    var time = observation.GetPhenomenonTime(true);                    
                    var res = Convert.ToDouble(observation.Result);
                    lineSerie.Points.Add(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(time), res));
                }
            }

            plotModel.Series.Add(lineSerie);
            plotview.InvalidatePlot();
        }
        private void SetUpModel()
        {
            plotModel.LegendTitle = "Legend";
            plotModel.LegendOrientation = LegendOrientation.Horizontal;
            plotModel.LegendPlacement = LegendPlacement.Outside;
            plotModel.LegendPosition = LegendPosition.TopRight;
            plotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            plotModel.LegendBorder = OxyColors.Black;
            plotModel.Title = "SensorThings API Sample Graph";
            var dtaxis = new OxyPlot.Axes.DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                TitleFormatString = "yy/mm/dd HH:mm"
            };
            plotModel.Axes.Add(dtaxis);            
            var valueAxis = new OxyPlot.Axes.LinearAxis() { MajorGridlineStyle = LineStyle.Solid, MinorGridlineStyle = LineStyle.Dot, Title = "Value" };
            valueAxis.Position = AxisPosition.Left;
            plotModel.Axes.Add(valueAxis);
        }

        private void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var str = Encoding.Default.GetString(e.Message);
            var observation = JsonConvert.DeserializeObject<Observation>(str);
            var lineSerie = plotModel.Series[0] as OxyPlot.Series.LineSeries;
            var xaxis = plotModel.Axes.First();
            var maxx = xaxis.ActualMaximum;

            if (observation.PhenomenonTime != null)
            {
                var time = observation.GetPhenomenonTime(true).Value;                
                var newmaxx = OxyPlot.Axes.DateTimeAxis.ToDouble(time);
                lineSerie.Points.Add(new DataPoint(newmaxx, (double)observation.Result));
                if (newmaxx > maxx)
                {
                    var step = (newmaxx - maxx) / xaxis.Scale;
                    xaxis.Pan(-step);
                }

                plotview.InvalidatePlot();
                Console.WriteLine("New Observation published: " + time + ", " + observation.Result);
            }

        }
    }
}