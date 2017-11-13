using PrivateBudgetManagerAPI.Db;
using PrivateBudgetManagerAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PrivateBudgetManagerAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();

        public List<Transactions> Get()
        {
            return transactionsDb.GetTransactions();
        }
        
        public Transactions Get(int id)
        {
            return transactionsDb.GetTransactions().Find(transaction => transaction.Id == id);
        }

        public void Post([FromBody]Transactions inputTransaction)
        {
            transactionsDb.CreateTransaction(inputTransaction);
        }
        
        public void Put([FromBody]Transactions inputTransaction)
        {
            transactionsDb.EditTransaction(inputTransaction);
        }
        
        public void Delete(int id)
        {
            transactionsDb.DeleteTransaction(id);
        }
    }
}