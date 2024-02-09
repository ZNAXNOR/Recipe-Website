namespace RecipeWebsite.ViewModels.CollectionViewModel
{
    public class EditCollectionViewModel
    {
        // Collection
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
    }
}
