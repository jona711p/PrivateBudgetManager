using Newtonsoft.Json.Linq;
using PrivateBudgetManager.Models;
using System.Collections.Generic;
using WebSocketSharp;

namespace PrivateBudgetManager.ExternalAPIs
{
    public class PDFAPI
    {
        static string uri = "ws://privatebudgetmanagerwebsocket.herokuapp.com/generatePDF/";

        public static void GeneratePDF(List<Transactions> transactionsList)
        {
            JArray jArray = JArray.FromObject(transactionsList);

            using (WebSocket ws = new WebSocket(uri))
            {
                ws.Connect();
                ws.Send(jArray.ToString());
            }
        }
    }
}