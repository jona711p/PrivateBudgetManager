using PrivateBudgetManager.ExternalAPIs;
using PrivateBudgetManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsController : Controller
    {
        public ActionResult Index()
        {
            Logging("202 Accepted",
                "Request: Get a list of Transactions from the Transactions API");

            List<Transactions> transactionList = TransactionsAPI.GetTransactions();

            if (transactionList != null)
            {
                Logging("200 OK",
                    "Response: Rescived a list of Transactions from the Transactions API");
            }
            else
            {
                Logging("404 Not Found",
                    "Response: Did NOT received a list of Transactions from the Transactions API");
            }

            return View(transactionList);
        }

        public ActionResult Details(int id)
        {
            Logging("202 Accepted",
                "Request: See the data from Transaction with ID: " + id);

            Transactions transaction = TransactionsAPI.GetTransaction(id);

            if (transaction != null)
            {
                Logging("200 OK",
                    "Response: Data from Transaction with ID: " + id + " was received from the Transaction API");
            }
            else
            {
                Logging("404 Not Found",
                    "Response: Did NOT received data for the givin' Transaction from the Transactions API");
            }

            return View(transaction);
        }

        public ActionResult Create()
        {
            SelectList categoriesList = new SelectList(CategoriesAPI.GetCategories(), "CatName", "CatId");

            ViewBag.categoriesList = categoriesList;

            Logging("202 Accepted",
                "Request: Gets the 'Create Transaction' Page");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Transactions inputTransaction)
        {
            try
            {
                Logging("202 Accepted",
                    "Request: Create a new Transaction with the following" +
                    ": Value: " + inputTransaction.Value +
                    ", Text: " + inputTransaction.Text +
                    ", Category: " + inputTransaction.CatName);

                HttpResponseMessage response = TransactionsAPI.CreateTransaction(inputTransaction);

                Logging(response.ToString(),
                    "Response: A new Transaction was send to the Transaction API to be created, with the following" +
                    ": Value: " + inputTransaction.Value +
                    ", Text: " + inputTransaction.Text +
                    ", Category: " + inputTransaction.CatName);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logging("400 Bad Request",
                    "Response: Could not pass the data to the Transaction API. Exception: " + ex);

                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Logging("202 Accepted",
                "Request: Gets the 'Edit Transaction' Page");

            return View(TransactionsAPI.GetTransaction(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Transactions inputTransaction)
        {
            try
            {
                HttpResponseMessage response = TransactionsAPI.EditTransaction(inputTransaction);

                Logging(response.ToString(),
                    "Request: Update Transaction with ID: " + inputTransaction.Id + " was send to the Transaction API to be updated, with the following" +
                    ": Value: " + inputTransaction.Value +
                    ", Text: " + inputTransaction.Text);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logging("400 Bad Request",
                    "Response: Could not pass the data to the Transaction API. Exception: " + ex);

                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Logging("202 Accepted",
                "Request: Gets the 'Delete Transaction' Page");

            return View(TransactionsAPI.GetTransaction(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Transactions inputTransaction)
        {
            try
            {
                Logging("202 Accepted",
                    "Request: Delete the Transaction with ID: " + id);

                HttpResponseMessage response = TransactionsAPI.DeleteTransaction(id);

                Logging(response.ToString(),
                    "Response: Transaction with the : " + id + " was send to the Transaction API to be deleted");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logging("400 Bad Request",
                    "Response: Could not pass the data to the Transaction API. Exception: " + ex);

                return View();
            }
        }

        public ActionResult PDF()
        {
            Logging("202 Accepted",
                "Request: Gets the 'PDF' Page");

            DateTime? fromDate = null;
            DateTime? toDate = null;

            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;

            return View();
        }

        [HttpPost]
        public ActionResult PDF(DateTime fromDate, DateTime toDate)
        {
            try
            {
                Logging("200 OK",
                    "Request: Generate a PDF with data from Transaction between " +
                    fromDate + " & " + toDate);

                List<Transactions> transactionsList = TransactionsAPI.GetTransactions()
                    .Where(transactions => transactions.Date >= fromDate && transactions.Date <= toDate)
                    .ToList();

                if (transactionsList.Count == 0)
                {
                    Logging("400 Bad Request",
                        "Response: There where no data between " + fromDate + " & " + toDate);

                    return View();
                }

                PDFAPI.GeneratePDF(transactionsList);

                Logging("200 OK",
                    "Response: Data was collected from the database and send to the Generate PDF API");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logging("400 Bad Request",
                    "Response: Could not pass the data to the Transaction API. Exception: " + ex);

                return RedirectToAction("PDF");
            }
        }

        private void Logging(string statusCode, string logEntry)
        {
            // Temp User
            string user = "PrivateBudgetManagerMVC";

            LoggingAPI.NewLogEntry(statusCode, user, logEntry);
        }
    }
}