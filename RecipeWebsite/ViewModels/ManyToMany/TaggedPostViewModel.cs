using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.ManyToMany
{
    public class TaggedPostViewModel
    {
        public List<CategoryModel> Categories { get; set; }

        public List<TagsModel>? Tags { get; set; }
        public TagsModel? TagInfo { get; set; }
    }
}
