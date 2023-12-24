using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.PostViewModel
{
    public class EditPostViewModel
    {
        // Post
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? Ingredient { get; set; }
        public string Recipe { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }

        // Category
        public int Category { get; set; }
        public List<string>? Tags { get; set; }

        // Category List
        public List<CategoryModel>? CategoryList { get; set; }
        public List<TagsModel>? TagsList { get; set; }

        // Addition
        public DateTime Date {  get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
