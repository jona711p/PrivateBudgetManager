using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using PrivateBudgetManager.Db;

namespace PrivateBudgetManager.Controllers
{
    public class CategoriesAPIController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();
        Dictionary<int, string> tempDictionary = new Dictionary<int, string>();

        // GET: api/CategoriesAPI
        public Dictionary<int, string> Get()
        {
            List<SelectListItem> tempSelectListItem = transactionsDb.GetCategories();

            tempDictionary.Clear();

            foreach (SelectListItem item in tempSelectListItem)
            {
                tempDictionary.Add(int.Parse(item.Value), item.Text);
            }

            return tempDictionary;
        }

        // GET: api/CategoriesAPI/5
        public Dictionary<int, string> Get(int id)
        {
            List<SelectListItem> tempSelectListItem = transactionsDb.GetCategories();

            tempDictionary.Clear();

            foreach (SelectListItem item in tempSelectListItem)
            {
                if (int.Parse(item.Value) == id)
                {
                    tempDictionary.Add(int.Parse(item.Value), item.Text);
                }
            }

            return tempDictionary;
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
