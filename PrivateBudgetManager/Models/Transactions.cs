using System;
using System.ComponentModel.DataAnnotations;

namespace PrivateBudgetManager.Models
{
    public class Transactions : Categories
    {
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