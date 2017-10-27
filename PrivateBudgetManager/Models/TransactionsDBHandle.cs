using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PrivateBudgetManager.Models
{
    public class TransactionsDBHandle
    {
        private SqlConnection connection;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["PrivateBudgetManager"].ToString();
            connection = new SqlConnection(constring);
        }

        public List<Transactions> GetTransactions()
        {
            Connection();
            List<Transactions> transactionsList = new List<Transactions>();

            SqlCommand cmd = new SqlCommand("SELECT Category.[Name], Transactions.[Value], Transactions.[Date], Transactions.[Text]" +
                                            " FROM Category INNER JOIN Transactions ON  Category.ID = Transactions.FK_CatID", connection);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            sd.Fill(dt);
            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                transactionsList.Add(
                    new Transactions
                    {
                        CatName = Convert.ToString(row["Name"]),
                        TransValue = float.Parse(row["Value"].ToString()),
                        //TransDateTime = Convert.ToDateTime(row["Date"]),
                        TransText = Convert.ToString(row["Text"])
                    });
            }

            return transactionsList;
        }
    }
}