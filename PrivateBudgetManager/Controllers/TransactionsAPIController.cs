using System.Collections.Generic;
using System.Web.Http;
using PrivateBudgetManager.Db;
using PrivateBudgetManager.Models;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsAPIController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();
        
        // GET: api/TransactionsAPI
        public List<Transactions> Get()
        {
            return transactionsDb.GetTransactions();
        }

        // GET: api/TransactionsAPI/5
        public Transactions Get(int id)
        {
            return transactionsDb.GetTransactions().Find(transaction => transaction.Id == id);
        }

        // POST: api/TransactionsAPI
        public void Post([FromBody]string value)
        {
            //transactionsDb.CreateTransaction(inputTransaction);
        }

        // PUT: api/TransactionsAPI/5
        public void Put(int id, [FromBody]string value)
        {
            //transactionsDb.EditTransaction(id, inputTransaction);
        }

        // DELETE: api/TransactionsAPI/5
        public void Delete(int id)
        {
            //transactionsDb.DeleteTransaction(id);
        }
    }
}
