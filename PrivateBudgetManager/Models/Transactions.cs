using System;
using System.ComponentModel.DataAnnotations;

namespace PrivateBudgetManager.Models
{
    public class Transactions
    {
        [Display(Name = "Transfer ID")]
        public int Id { get; set; }

        [Display(Name = "Transfer Værdi")]
        public float Value { get; set; }

        [Display(Name = "Transfer Dato")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "Transfer Tekst")]
        public string Text { get; set; }

        [Display(Name = "Kategori ID")]
        public int CatId { get; set; }

        [Display(Name = "Kategori")]
        public string CatName { get; set; }

        [Display(Name = "Kategori ID")]
        public int CatFK_SubcatId { get; set; }
    }
}