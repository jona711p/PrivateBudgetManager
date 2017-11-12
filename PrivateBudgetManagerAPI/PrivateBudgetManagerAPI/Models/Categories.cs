using System.ComponentModel.DataAnnotations;

namespace PrivateBudgetManagerAPI.Models
{
    public class Categories
    {
        [Display(Name = "Kategori ID")]
        public int CatId { get; set; }

        [Display(Name = "Kategori")]
        public string CatName { get; set; }

        [Display(Name = "Underkategori ID")]
        public int CatFK_SubcatId { get; set; }
    }
}