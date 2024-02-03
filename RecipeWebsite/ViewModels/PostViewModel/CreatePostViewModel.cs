using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.PostViewModel
{
    public class CreatePostViewModel
    {
        // Post
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? Ingredient { get; set; }
        public string Recipe { get; set; }
        public IFormFile Image { get; set; }

        // Category
        public int Category { get; set; }
        public List<int>? Tags { get; set; }

        // Category List
        public List<CategoryModel>? CategoryList { get; set; }
        public List<TagsModel>? TagsList { get; set; }

        // Addition
        public int View { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
