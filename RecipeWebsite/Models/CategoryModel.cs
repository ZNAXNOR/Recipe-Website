using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class CategoryModel
    {
        // Post
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
