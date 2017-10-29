using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using PrivateBudgetManager.Models;

namespace PrivateBudgetManager.Db
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
                transactionsList.Add(
                    new Transactions
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Value = int.Parse(row["Value"].ToString()),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        Text = row["Text"].ToString(),
                        CatId = int.Parse(row["FK_CatId"].ToString()),
                        CatName = row["Name"].ToString(),
                        CatFK_SubcatId = int.Parse(row["FK_SubcatId"].ToString())
                    });
            }

            return transactionsList;
        }

        public List<SelectListItem> GetCategories()
        {
            Connection();

            List<SelectListItem> categoriesList = new List<SelectListItem>();

            DataTable dataTable = new DataTable();

            SqlCommand command = new SqlCommand("sp_GetCategories", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            connection.Open();
            adapter.Fill(dataTable);
            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                categoriesList.Add(new SelectListItem
                {
                    Text = row["Name"].ToString(),
                    Value = row["Id"].ToString()
                });
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

        public void EditTransaction(int id, Transactions inputTransaction)
        {
            Connection();

            SqlCommand command = new SqlCommand("sp_EditTransaction", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Value", SqlDbType.Int).Value = inputTransaction.Value;
            command.Parameters.Add("@Date", SqlDbType.DateTime).Value = inputTransaction.Date;
            command.Parameters.Add("@Text", SqlDbType.NVarChar).Value = inputTransaction.Text;

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

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