using System.Data;

namespace PrivateBudgetManagerAPI.Models
{
    public class Categories
    {
        public Categories()
        {
        }

        public Categories(DataRow row, int SubcatId)
        {
            CatName = row["Name"].ToString();
            CatId = int.Parse(row["Id"].ToString());
            CatFK_SubcatId = SubcatId;
        }

        public int CatId { get; set; }

        public string CatName { get; set; }

        public int CatFK_SubcatId { get; set; }
    }
}