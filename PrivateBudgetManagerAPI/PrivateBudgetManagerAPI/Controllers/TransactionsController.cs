using PrivateBudgetManagerAPI.Db;
using PrivateBudgetManagerAPI.ExternalAPIs;
using PrivateBudgetManagerAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace PrivateBudgetManagerAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        TransactionsDb transactionsDb = new TransactionsDb();

        /// <summary>
        /// A list of all Transactions in the DB
        /// </summary>
        /// <returns></returns>
        public List<Transactions> Get()
        {
            Logging("202 Accepted",
                "Request: Generate a new list of Transaction from the DB");

            List<Transactions> tempTransactionsList = transactionsDb.GetTransactions();

            Logging("201 Created",
                "Response: Transaction list was created, and is beeing send to the user");

            return tempTransactionsList;
        }
        
        /// <summary>
        /// Shows the data from a Transaction from a specific ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Transactions Get(int id)
        {
            Logging("202 Accepted",
                "Request: See the data from Transaction with ID: " + id);

            Transactions tempTransaction = transactionsDb.GetTransactions().Find(transaction => transaction.Id == id);

            Logging("201 Created",
                "Response: Data from Transaction with ID: " + id + " was generated from the DB and send to the user");

            return tempTransaction;
        }

        /// <summary>
        /// Create a Transaction in the DB
        /// </summary>
        /// <param name="inputTransaction">Required: Value, Text & CatId</param>
        public void Post([FromBody]Transactions inputTransaction)
        {
            Logging("202 Accepted",
                "Request: Create a new Transaction with the following" +
                ": Value: " + inputTransaction.Value + 
                ", Text: " + inputTransaction.Text + 
                ", Category: "+ inputTransaction.CatName);

            transactionsDb.CreateTransaction(inputTransaction);

            Logging("201 Created",
                "Response: A new Transaction was created in the DB, with the following" +
                ": Value: " + inputTransaction.Value +
                ", Text: " + inputTransaction.Text +
                ", Category: " + inputTransaction.CatName);
        }

        /// <summary>
        /// Update a Transaction by ID in the DB
        /// </summary>
        /// <param name="inputTransaction">Required: Id, Value & Text</param>
        public void Put([FromBody]Transactions inputTransaction)
        {
            Logging("202 Accepted",
                "Request: Update Transaction with ID: " + inputTransaction.Id + " with the following" +
                ": Value: " + inputTransaction.Value +
                ", Text: " + inputTransaction.Text);

            transactionsDb.EditTransaction(inputTransaction);

            Logging("200 OK",
                "Response: Transaction with ID: " + inputTransaction.Id + " was updated in the DB, with the following" +
                ": Value: " + inputTransaction.Value +
                ", Text: " + inputTransaction.Text);
        }
        
        /// <summary>
        /// Delete a Transaction from the DB
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Logging("202 Accepted",
                "Request: Delete the Transaction with ID: " + id);

            transactionsDb.DeleteTransaction(id);
        
            Logging("200 OK",
                "Response: Transaction with the : " + id + "was deleted from the DB");
        }

        private void Logging(string statusCode, string logEntry)
        {
            // Temp User
            string user = "PrivateBudgetManagerAPI";

            LoggingAPI.NewLogEntry(statusCode, user, logEntry);
        }
    }
}