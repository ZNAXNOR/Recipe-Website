using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SimpleWebsite.Models;

namespace RecipeWebsite.Models
{
    public class CollectionModel
    {
        // Collection
        [Key]
        public int CollectionId { get; set; }
        public string CollectionTitle { get; set; }
        public string? CollectionDescription { get; set; }
        public string CollectionImage { get; set; }

        public List<PostModel> Posts { get; set; }
        public virtual List<PostCollectionModel> PostCollections { get; set; }
        
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUserModel? AppUser { get; set; }
    }
}
