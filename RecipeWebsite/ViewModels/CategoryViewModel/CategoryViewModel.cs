using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.CategoryViewModel
{
    public class CategoryViewModel
    {
        public List<PostCategoryModel>? PostCategories { get; set; }
        public List<TagsModel>? RecipeTags { get; set; }
    }
}
