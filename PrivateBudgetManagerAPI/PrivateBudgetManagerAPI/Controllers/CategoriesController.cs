using PrivateBudgetManagerAPI.Db;
using PrivateBudgetManagerAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PrivateBudgetManagerAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();

        public List<Categories> Get()
        {
            return transactionsDb.GetCategories();
        }
    }
}
