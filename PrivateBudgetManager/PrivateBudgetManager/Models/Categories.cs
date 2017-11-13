using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace PrivateBudgetManager.Models
{
    public class Categories
    {
        public Categories()
        {
        }

        public Categories(JObject jObject)
        {
            CatId = int.Parse(jObject["CatId"].ToString());
            CatName = jObject["CatName"].ToString();
            CatFK_SubcatId = int.Parse(jObject["CatFK_SubcatId"].ToString());
        }

        [Display(Name = "Kategori ID")]
        public int CatId { get; set; }

        [Display(Name = "Kategori")]
        public string CatName { get; set; }

        [Display(Name = "Underkategori ID")]
        public int CatFK_SubcatId { get; set; }
    }
}