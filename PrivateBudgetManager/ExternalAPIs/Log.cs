using System;
using System.Net.Http;

namespace PrivateBudgetManager.ExternalAPIs
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

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://privatebudgetmanagerloggingapi.herokuapp.com/");

                HttpResponseMessage response = client.PostAsJsonAsync("logs/", log).Result;

                //if (response.IsSuccessStatusCode)
                //{
                //    Console.Write("Success");
                //}

                //else
                //{
                //    Console.Write("Error");
                //}
            }
        }
    }
}
