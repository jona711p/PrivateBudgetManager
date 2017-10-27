using System.Collections.Generic;
using System.Web.Http;

namespace PrivateBudgetManager.Controllers
{
    public class TransactionsAPIController : ApiController
    {
        // GET: api/TransactionsAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TransactionsAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TransactionsAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TransactionsAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TransactionsAPI/5
        public void Delete(int id)
        {
        }
    }
}
