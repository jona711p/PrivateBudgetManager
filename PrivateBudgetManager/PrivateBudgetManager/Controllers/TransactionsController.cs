using System;
using System.Linq;
using PrivateBudgetManager.ExternalAPIs;
using PrivateBudgetManager.Models;
using System.Web.Mvc;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsController : Controller
    {
        public ActionResult Index()
        {
            return View(TransactionsAPI.GetTransactions());
        }
        
        public ActionResult Details(int id)
        {
            return View(TransactionsAPI.GetTransaction(id));
        }
        
        public ActionResult Create()
        {
            SelectList categoriesList = new SelectList(CategoriesAPI.GetCategories(), "CatName", "CatId");

            ViewBag.categoriesList = categoriesList;

            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Transactions inputTransaction)
        {
            try
            {
                TransactionsAPI.CreateTransaction(inputTransaction);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View(TransactionsAPI.GetTransaction(id));
        }
        
        [HttpPost]
        public ActionResult Edit(int id, Transactions inputTransaction)
        {
            try
            {
                TransactionsAPI.EditTransaction(inputTransaction);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            return View(TransactionsAPI.GetTransaction(id));
        }
                
        [HttpPost]
        public ActionResult Delete(int id, Transactions inputTransaction)
        {
            try
            {
                TransactionsAPI.DeleteTransaction(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PDF()
        {
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
                PDFAPI.GeneratePDF(TransactionsAPI.GetTransactions().Where(transactions => transactions.Date >= fromDate && transactions.Date <= toDate).ToList());

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("PDF");
            }
        }
    }
}