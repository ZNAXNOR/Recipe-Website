using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class CollectionCategoryModel
    {
        // Collection
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
