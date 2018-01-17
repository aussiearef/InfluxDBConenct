using System;
using System.Collections.Generic;

namespace InfluxDBConnect
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hello! Learn about Grafana at https://www.udemy.com/grafana-graphite-and-statsd-visualize-metrics");
            Console.Write("Please press Ctrl-C to stop!");

            var influxDbClient = new InfluxDBClient("http://ec2-54-252-238-183.ap-southeast-2.compute.amazonaws.com");

            const string measurement= "cpu";
            const string dbName = "demo";

            while (true)
            {

                influxDbClient.SendPoint(dbName, measurement,
                                         new KeyValuePair<string, float>("value", new Random((int)DateTime.Now.Ticks).Next(100)),
                                         new KeyValuePair<string, string>("host", "ServerA"));
            }
        }
    }
}
