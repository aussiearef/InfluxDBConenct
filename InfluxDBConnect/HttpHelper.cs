using System;
using System.Net;
using System.Net.Http;
namespace InfluxDBConnect
{
    public static class HttpHelper
    {
        public static HttpStatusCode Post(Uri address, string data)
        {
            var client = new HttpClient();
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(data));

            var postTask = client.PostAsync(address, content);
            postTask.Wait();

            return postTask.Result.StatusCode;
        }

    }
}
