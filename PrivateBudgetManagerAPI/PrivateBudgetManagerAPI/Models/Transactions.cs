using System;
using System.Data;

namespace PrivateBudgetManagerAPI.Models
{
    public class Transactions : Categories
    {
        public Transactions()
        {
        }

        public Transactions(DataRow row)
        {
            Id = int.Parse(row["Id"].ToString());
            Value = int.Parse(row["Value"].ToString());
            Date = DateTime.Parse(row["Date"].ToString());
            Text = row["Text"].ToString();
            CatId = int.Parse(row["FK_CatId"].ToString());
            CatName = row["Name"].ToString();
            CatFK_SubcatId = int.Parse(row["FK_SubcatId"].ToString());
        }

        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}