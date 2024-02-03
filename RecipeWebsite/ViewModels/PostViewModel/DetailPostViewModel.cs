using RecipeWebsite.Models;
using SimpleWebsite.ViewModels;

namespace RecipeWebsite.ViewModels.PostViewModel
{
    public class DetailPostViewModel
    {
        public PostModel Posts { get; set; }
        public List<CategoryModel>? Categories { get; set; }
        //public List<TagsModel>? Tags { get; set; }
        public List<SelectedItemViewModel> Tags { get; set; }
    }
}
