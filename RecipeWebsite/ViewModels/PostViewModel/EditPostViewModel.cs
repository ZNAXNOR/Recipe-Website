namespace RecipeWebsite.ViewModels.PostViewModel
{
    public class EditPostViewModel
    {
        // Post
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? Ingredient { get; set; }
        public string Recipe { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }

        // Category
        //public PostCategory PostCategory { get; set; }
        //public CollectionCategory CollectionCategory { get; set; }
    }
}
