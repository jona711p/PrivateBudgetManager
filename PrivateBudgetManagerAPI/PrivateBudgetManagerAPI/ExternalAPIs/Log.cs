using System;
using System.Net.Http;

namespace PrivateBudgetManagerAPI.ExternalAPIs
{
    public class Log
    {
        public string user { get; set; }
        public string logEntry { get; set; }

        public static void NewLog(string inputUser, string inputLogEntry)
        {
            Log log = new Log();

            log.user = inputUser;
            log.logEntry = inputLogEntry;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://privatebudgetmanagerloggingapi.herokuapp.com/");
            HttpResponseMessage response = client.PostAsJsonAsync("logs/", log).Result;
        }
    }
}