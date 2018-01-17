using System;
using System.Collections.Generic;
using System.Linq;

namespace InfluxDBConnect
{
    public class InfluxDBClient
    {
        private readonly string _address;
        private readonly int _port;

        public InfluxDBClient(string address, int port = 8086)
        {
            _address = address;
            _port = port;
        }
        public bool SendPoint(string dbName,string measurement, KeyValuePair<string, float> value, params KeyValuePair<string, string>[] tags)
        {
            //cpu,host=ServerA,region=US valueKey=value

            var tagsList = tags.Select(tag => $"{tag.Key}={tag.Value}");
            var tagListString = string.Join(",", tagsList);

            var data = $"{measurement},{tagListString} {value.Key}={value.Value}";

            var httpResult = HttpHelper.Post(new Uri($"{_address}:{_port}/write?db={dbName}"), data);
            return httpResult == System.Net.HttpStatusCode.NoContent;
        }
    }
}
