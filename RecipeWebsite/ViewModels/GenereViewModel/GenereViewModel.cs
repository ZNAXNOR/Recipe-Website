using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.GenereViewModel
{
    public class GenereViewModel
    {
        public List<CategoryModel>? PostCategories { get; set; }
        public List<TagsModel>? RecipeTags { get; set; }
    }
}
