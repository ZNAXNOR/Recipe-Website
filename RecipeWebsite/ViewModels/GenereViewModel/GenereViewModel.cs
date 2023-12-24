using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.GenereViewModel
{
    public class GenereViewModel
    {
        public List<PostCategoryModel>? PostCategories { get; set; }
        public List<TagsModel>? RecipeTags { get; set; }
    }
}
