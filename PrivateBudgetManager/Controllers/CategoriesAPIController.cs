using System.Collections.Generic;
using System.Web.Http;
using PrivateBudgetManager.Db;
using PrivateBudgetManager.Models;

namespace PrivateBudgetManager.Controllers
{
    public class CategoriesAPIController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();

        // GET: api/CategoriesAPI
        public List<Categories> Get()
        {
            return transactionsDb.GetCategories();
        }

        // GET: api/CategoriesAPI/5
        public Categories Get(int id)
        {
            return transactionsDb.GetCategories().Find(transaction => transaction.CatId == id);
        }

        // POST: api/CategoriesAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CategoriesAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CategoriesAPI/5
        public void Delete(int id)
        {
        }
    }
}
