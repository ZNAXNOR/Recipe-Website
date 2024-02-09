using RecipeWebsite.Models;

namespace SimpleWebsite.Models
{
    public class PostCollectionModel
    {
        public int PostId { get; set; }
        public int CollectionId { get; set; }


        // Many to Many relationship
        public virtual PostModel Post { get; set; }
        public virtual CollectionModel Collection { get; set; }
    }
}
