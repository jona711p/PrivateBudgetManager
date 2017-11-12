using PrivateBudgetManagerAPI.Db;
using System.Collections.Generic;
using System.Web.Http;
using PrivateBudgetManagerAPI.Models;

namespace PrivateBudgetManagerAPI.Controllers
{
    public class TransactionsAPIController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();

        // GET: TransactionsAPI
        public List<Transactions> Get()
        {
            string tempUser = "Admin";
            string tempLogEntry = $"Fetched a full transactionlist";

            ExternalAPIs.Log.NewLog(tempUser, tempLogEntry);

            return transactionsDb.GetTransactions();
        }

        // GET: TransactionsAPI/5
        public Transactions Get(int id)
        {
            return transactionsDb.GetTransactions().Find(transaction => transaction.Id == id);
        }

        // POST: TransactionsAPI
        public void Post([FromBody]string value)
        {
            //transactionsDb.CreateTransaction(inputTransaction);
        }

        // PUT: TransactionsAPI/5
        public void Put(int id, [FromBody]string value)
        {
            //transactionsDb.EditTransaction(id, inputTransaction);
        }

        // DELETE: TransactionsAPI/5
        public void Delete(int id)
        {
            //transactionsDb.DeleteTransaction(id);
        }
    }
}
