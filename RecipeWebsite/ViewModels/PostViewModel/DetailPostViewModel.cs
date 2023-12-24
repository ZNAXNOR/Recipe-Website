using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.PostViewModel
{
    public class DetailPostViewModel
    {
        public PostModel Posts { get; set; }
        public List<TagsModel>? Tags { get; set; }
    }
}
