using System;
using System.ComponentModel.DataAnnotations;

namespace PrivateBudgetManager.Models
{
    public class Transactions
    {
        [Display(Name = "Transfer ID")]
        public int TransID { get; set; }

        [Required(ErrorMessage = "Transfer Værdig")]
        public float TransValue { get; set; }

        [Required(ErrorMessage = "Transfer Dato")]
        public DateTime TransDateTime { get; set; }

        [Required(ErrorMessage = "Transfer Tekst")]
        public string TransText { get; set; }

        [Required(ErrorMessage = "Transfer Kategori ID")]
        public int Trans_FK_CatID { get; set; }

        [Required(ErrorMessage = "Kategori ID")]
        public int CatID { get; set; }

        [Required(ErrorMessage = "Kategori")]
        public string CatName { get; set; }

        [Required(ErrorMessage = "Kategori ID")]
        public int Cat_FK_CatID { get; set; }
    }
}