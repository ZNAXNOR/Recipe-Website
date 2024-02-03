using RecipeWebsite.Models;
using SimpleWebsite.ViewModels;

namespace RecipeWebsite.ViewModels.CardsViewModel
{
    public class CardsViewModel
    {
        // Cards
        public List<PostModel>? PostCard { get; set; }
        public List<CollectionModel>? CollectionCard { get; set; }


        // Category
        public List<CategoryModel> Categories { get; set; }

        // Category Information
        public CategoryModel? CategoryInfo { get; set; }


        // Tags
        public List<TagsModel>? Tags { get; set; }

        // Tags Information
        public TagsModel? TagInfo { get; set; }
    }
}
