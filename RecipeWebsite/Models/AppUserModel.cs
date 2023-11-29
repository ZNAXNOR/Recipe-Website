using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class AppUserModel
    {
        // Applcation
        [Key]
        public string Id { get; set; }
        public string? Category { get; set; }
        public ICollection<CollectionModel> Collections { get; set; }
        public ICollection<PostModel> Posts { get; set; }


        // Account
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
