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
            //SelectList categoriesList = new SelectList(transactionsAPI.GetCategories(), "CatName", "CatId");

            //ViewBag.categoriesList = categoriesList;

            return View();
        }
        
        //[HttpPost]
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
            return View();
        }
        
        //[HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            return View();
        }
                
        //[HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PDF()
        {
            return View();
        }

        public ActionResult GeneratePDF()
        {
            try
            {
                //fromDate = DateTime.Parse("2017-10-28T00:00:00");
                //toDate = DateTime.Parse("2017-11-03T00:00:00");

                PDFAPI.GeneratePDF(TransactionsAPI.GetTransactions());

                return RedirectToAction("Index");
            }
            catch
            {
                return null;//View();
            }
        }
    }
}