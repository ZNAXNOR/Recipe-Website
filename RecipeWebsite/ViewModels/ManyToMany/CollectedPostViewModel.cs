using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.ManyToMany
{
    public class CollectedPostViewModel
    {
        public List<CategoryModel> Categories { get; set; }

        public List<TagsModel>? Tags { get; set; }

        public List<CollectionModel>? Collections { get; set; }
        public CollectionModel? CollectionInfo { get; set; }
    }
}
