using System;
using System.Net.Http;

namespace PrivateBudgetManager.ExternalAPIs
{
    public class PDF
    {
        public string fromDate { get; set; }

        public string toDate { get; set; }

        public static Uri GetPDF(string inputFromDate, string inputToDate)
        {
            PDF pdf = new PDF();

            pdf.fromDate = inputFromDate;
            pdf.toDate = inputToDate;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://privatebudgetmanagerpdfapi.herokuapp.com/");

                HttpResponseMessage response = client.PostAsJsonAsync("/pdf", pdf).Result;

                return response.RequestMessage.RequestUri;
            }
        }
    }
}