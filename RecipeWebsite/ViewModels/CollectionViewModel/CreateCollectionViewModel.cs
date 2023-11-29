namespace RecipeWebsite.ViewModels.CollectionViewModel
{
    public class CreateCollectionViewModel
    {
        // Collection
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }

        // Collection
        //public CollectionCategory CollectionCategory { get; set; }
    }
}
