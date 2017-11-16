using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace PrivateBudgetManagerAPI.ExternalAPIs
{
    public class LoggingAPI
    {
        public string statusCode { get; set; }

        public string user { get; set; }

        public string logEntry { get; set; }

        static Uri uri = new Uri("https://privatebudgetmanagerloggingapi.herokuapp.com/logs/");

        public LoggingAPI(string inputStatusCode, string inputUser, string inputLogEntry)
        {
            statusCode = inputStatusCode;
            user = inputUser;
            logEntry = inputLogEntry;
        }

        public static void NewLogEntry(string inputStatusCode, string inputUser, string inputLogEntry)
        {
            LoggingAPI log = new LoggingAPI(inputStatusCode, inputUser, inputLogEntry);

            using (HttpClient client = new HttpClient())
            {
                JObject jObject = JObject.FromObject(log);

                StringContent content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(uri, content).Result;
            }
        }
    }
}