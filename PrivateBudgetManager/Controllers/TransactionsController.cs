using System.Web.Mvc;
using PrivateBudgetManager.Models;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsController : Controller
    {
        private TransactionsDBHandle transactionsDb = new TransactionsDBHandle();
        // GET: Transactions
        public ActionResult Index()
        {
            return View(transactionsDb.GetTransactions());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int id)
        {
            return View(transactionsDb.GetTransactions().Find(transaction => transaction.Id == id));
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
            return View(transactionsDb.GetTransactions().Find(transaction => transaction.Id == id));
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
    }
}
