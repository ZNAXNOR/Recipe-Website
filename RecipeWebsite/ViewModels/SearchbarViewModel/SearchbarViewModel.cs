using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.SearchbarViewModel
{
    public class SearchbarViewModel
    {
        public List<PostModel>? Posts { get; set; }
        public List<CollectionModel>? Collections { get; set; }
    }
}
