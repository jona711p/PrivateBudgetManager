using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace PrivateBudgetManager.Models
{
    public class Transactions : Categories
    {
        public Transactions()
        {
        }

        public Transactions(JObject jObject)
        {
            Id = int.Parse(jObject["Id"].ToString());
            Value = int.Parse(jObject["Value"].ToString());
            Date = DateTime.Parse(jObject["Date"].ToString());
            Text = jObject["Text"].ToString();
            CatId = int.Parse(jObject["CatId"].ToString());
            CatName = jObject["CatName"].ToString();
            CatFK_SubcatId = int.Parse(jObject["CatFK_SubcatId"].ToString());
        }


        [Display(Name = "Transfer ID")]
        public int Id { get; set; }

        [Display(Name = "Transfer Værdi")]
        [Required(ErrorMessage = "Du skal anføre en værdi")]
        public int Value { get; set; }

        [Display(Name = "Transfer Dato")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "Transfer Tekst")]
        [Required(ErrorMessage = "Du skal anføre en tekst")]
        public string Text { get; set; }
    }
}