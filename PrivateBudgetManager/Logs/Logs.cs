using System;
using System.Net.Http;

namespace PrivateBudgetManager.Logs
{
    public class Logs
    {
        public string user { get; set; }
        public string oldContent { get; set; }
        public string newContent { get; set; }

        public void NewLog(Logs inputLog)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3000/");

                HttpResponseMessage response = client.PostAsJsonAsync("logs/", inputLog).Result;

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
