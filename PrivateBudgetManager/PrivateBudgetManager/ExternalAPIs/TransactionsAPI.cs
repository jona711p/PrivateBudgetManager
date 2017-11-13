using Newtonsoft.Json.Linq;
using PrivateBudgetManager.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PrivateBudgetManager.ExternalAPIs
{
    public class TransactionsAPI
    {
        static Uri uri = new Uri("http://privatebudgetmanagerapi.azurewebsites.net/Transactions/");

        public static List<Transactions> GetTransactions()
        {
            List<Transactions> transactionsList = new List<Transactions>();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        HttpContent responseContent = response.Content;

                        JArray jArray = JArray.Parse(responseContent.ReadAsStringAsync().Result);

                        foreach (JObject jObject in jArray)
                        {
                            transactionsList.Add(new Transactions(jObject));
                        }
                    }
                }
            }

            return transactionsList;
        }

        public static Transactions GetTransaction(int id)
        {
            Transactions transaction = new Transactions();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(uri + id.ToString()).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (HttpContent content = response.Content)
                        {
                            string result = content.ReadAsStringAsync().Result;

                            transaction = new Transactions(JObject.Parse(result));
                        }
                    }
                }
            }
            return transaction;
        }

        public static void CreateTransaction(Transactions inputTransaction)
        {
            using (HttpClient client = new HttpClient())
            {
                JObject jObject = JObject.FromObject(inputTransaction);

                StringContent content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = client.PostAsync(uri, content).Result)
                {
                    
                }
            }
        }
    }
}