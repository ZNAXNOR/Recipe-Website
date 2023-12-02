using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class PostCategoryModel
    {
        // Post
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
