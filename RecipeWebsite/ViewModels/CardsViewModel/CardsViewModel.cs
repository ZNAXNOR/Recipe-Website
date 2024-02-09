using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.CardsViewModel
{
    public class CardsViewModel
    {
        public List<PostModel>? PostCard { get; set; }

        public List<CollectionModel>? CollectionCard { get; set; }
        public CollectionModel? CollectionInfo {  get; set; }

        public List<CategoryModel> Categories { get; set; }
        public CategoryModel? CategoryInfo { get; set; }

        public List<TagsModel>? Tags { get; set; }
        public TagsModel? TagInfo { get; set; }
    }
}
