using Newtonsoft.Json.Linq;
using PrivateBudgetManager.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PrivateBudgetManager.ExternalAPIs
{
    public class CategoriesAPI
    {
        static Uri uri = new Uri("http://privatebudgetmanagerapi.azurewebsites.net/Categories/");

        public static List<Categories> GetCategories()
        {
            List<Categories> categoriesList = new List<Categories>();

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
                            categoriesList.Add(new Categories(jObject));
                        }
                    }
                }
            }

            return categoriesList;
        }
    }
}