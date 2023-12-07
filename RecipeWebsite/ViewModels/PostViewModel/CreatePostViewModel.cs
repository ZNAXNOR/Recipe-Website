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
        public string PostCategory { get; set; }
        public List<string>? CollectionCategory { get; set; }

        // Category List
        public List<PostCategoryModel>? PostCategoryList { get; set; }
        public List<CollectionCategoryModel>? CollectionCategoryList { get; set; }
    }
}
