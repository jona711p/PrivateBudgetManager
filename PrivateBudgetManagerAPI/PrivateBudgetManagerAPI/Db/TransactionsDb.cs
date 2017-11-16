using PrivateBudgetManagerAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PrivateBudgetManagerAPI.Db
{
    public class TransactionsDb
    {
        SqlConnection connection = null;

        private void Connection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PrivateBudgetManager"].ConnectionString);
        }

        public List<Transactions> GetTransactions()
        {
            Connection();

            List<Transactions> transactionsList = new List<Transactions>();
            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("sp_GetTransactions", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                transactionsList.Add(new Transactions(row));
            }

            return transactionsList;
        }

        public List<Categories> GetCategories()
        {
            Connection();

            List<Categories> categoriesList = new List<Categories>();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("sp_GetCategories", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            int tempInt;

            foreach (DataRow row in dataTable.Rows)
            {
                tempInt = 0;

                int.TryParse(row["FK_CatId"].ToString(), out tempInt);

                categoriesList.Add(new Categories(row, tempInt));
            }

            return categoriesList;
        }

        public void CreateTransaction(Transactions inputTransaction)
        {
            Connection();

            SqlCommand command = new SqlCommand("sp_CreateTransaction", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Value", SqlDbType.Int).Value = inputTransaction.Value;
            command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = inputTransaction.Text;
            command.Parameters.Add("@FK_CatId", SqlDbType.Int).Value = inputTransaction.CatId;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void EditTransaction(Transactions inputTransaction)
        {
            Connection();

            SqlCommand command = new SqlCommand("sp_EditTransaction", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Value", SqlDbType.Int).Value = inputTransaction.Value;
            command.Parameters.Add("@Date", SqlDbType.DateTime).Value = inputTransaction.Date;
            command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = inputTransaction.Text;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = inputTransaction.Id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteTransaction(int id)
        {
            Connection();

            SqlCommand command = new SqlCommand("sp_DeleteTransaction", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}