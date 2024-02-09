using RecipeWebsite.Models;
using SimpleWebsite.ViewModels;

namespace RecipeWebsite.ViewModels.PostViewModel
{
    public class DetailPostViewModel
    {
        public PostModel Posts { get; set; }
        public List<CategoryModel>? Categories { get; set; }

        // Collection
        public List<int>? Collections { get; set; }

        // Selected
        public List<SelectedItemViewModel> SelectedItems { get; set; }

        // Category List
        public List<CollectionModel>? CollectionList { get; set; }
    }
}
