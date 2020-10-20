using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace TestApiIvavn
{
    class Program
    {
        public static string BaseUrl = "http://192.168.43.73:8102/api/log";

        static void Main(string[] args)
        {
            Server server = new Server();
            server.server_name = "hello";
            server.region = "artemiy";
            server.ip = "2.2.3.1";
            server.people = 135;
            Check(server);
        }

        public static void Check(Server server)
        {
            string message = JsonConvert.SerializeObject(server);
            string response = "";

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                response = wc.UploadString(BaseUrl, message);
            }
        }
    }
}
