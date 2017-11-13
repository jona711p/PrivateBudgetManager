using Newtonsoft.Json.Linq;
using PrivateBudgetManager.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PrivateBudgetManager.ExternalAPIs
{
    public class PDFAPI
    {
        static Uri uri = new Uri("https://privatebudgetmanagerpdfapi.herokuapp.com/");

        public static void GeneratePDF(List<Transactions> transactionsList)
        {
            using (HttpClient client = new HttpClient())
            {
                JArray jArray = JArray.FromObject(transactionsList);

                StringContent content = new StringContent(jArray.ToString(), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = client.PostAsync(uri, content).Result)
                {

                }
            }
        }
    }
}