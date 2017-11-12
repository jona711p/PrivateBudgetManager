using PrivateBudgetManager.ExternalAPIs;
using System.Web.Mvc;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsController : Controller
    {
        TransactionsAPI transactionsAPI = new TransactionsAPI();

        // GET: Transactions
        public ActionResult Index()
        {
            return View(transactionsAPI.GetTransactions());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int id)
        {
            return View(transactionsAPI.GetTransaction(id));
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transactions/Edit/5
        [HttpPost]
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

        // GET: Transactions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transactions/Delete/5
        [HttpPost]
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

        //public ActionResult PDF()
        //{
        //    Uri downloadPDFURI = ExternalAPIs.PDF.GetPDF("2017-10-28T00:00:00", "2017-11-03T00:00:00");

        //    string downloadPDF = downloadPDFURI.AbsoluteUri;

        //    return Redirect(downloadPDF);
        //}
    }
}