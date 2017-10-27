using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PrivateBudgetManager.Models
{
    public class TransactionsDBHandle
    {
        private SqlConnection connection = null;

        private void Connection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PrivateBudgetManager"].ConnectionString);
        }

        public List<Transactions> GetTransactions()
        {
            Connection();

            List<Transactions> transactionsList = new List<Transactions>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM View_GetTransactions", connection);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sda.Fill(dt);
            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                transactionsList.Add(
                    new Transactions
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Value = float.Parse(row["Value"].ToString()),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        Text = row["Text"].ToString(),
                        CatId = int.Parse(row["FK_CatId"].ToString()),
                        CatName = row["Name"].ToString(),
                        CatFK_SubcatId = int.Parse(row["FK_SubcatId"].ToString())
                    });
                }

            return transactionsList;
        }
    }
}