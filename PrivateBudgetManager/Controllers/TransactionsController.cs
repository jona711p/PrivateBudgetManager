using System.Web.Mvc;
using PrivateBudgetManager.Db;
using PrivateBudgetManager.Models;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsController : Controller
    {
        TransactionsDb transactionsDb = new TransactionsDb();

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
            SelectList categoriesList = new SelectList(transactionsDb.GetCategories(), "CatName", "CatId");

            ViewBag.categoriesList = categoriesList;

            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        public ActionResult Create(Transactions inputTransaction)
        {
            try
            {
                transactionsDb.CreateTransaction(inputTransaction);

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
        public ActionResult Edit(int id, Transactions inputTransaction)
        {
            try
            {
                transactionsDb.EditTransaction(id, inputTransaction);

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
            return View(transactionsDb.GetTransactions().Find(transaction => transaction.Id == id));
        }

        // POST: Transactions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                transactionsDb.DeleteTransaction(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
