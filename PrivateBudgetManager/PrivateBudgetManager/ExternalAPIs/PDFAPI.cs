using Newtonsoft.Json.Linq;
using PrivateBudgetManager.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using WebSocketSharp;

namespace PrivateBudgetManager.ExternalAPIs
{
    public class PDFAPI
    {
        static string uri = "ws://privatebudgetmanagerwebsocket.herokuapp.com/generatePDF/";
        static Uri downloadURI;

        public static Uri GeneratePDF(List<Transactions> transactionsList)
        {
            JArray jArray = JArray.FromObject(transactionsList);

            using (WebSocket ws = new WebSocket(uri))
            {
                ws.OnMessage += (sender, e) =>
                {
                    DownloadPDF(e.Data);
                };

                ws.Connect();
                ws.Send(jArray.ToString());
                Thread.Sleep(4000);
            }

            return downloadURI;
        }

        private static void DownloadPDF(string response)
        {
            response = response.Replace("\"", "");
            response = response.Replace("\\", "");

            downloadURI = new Uri(response);
        }
    }
}