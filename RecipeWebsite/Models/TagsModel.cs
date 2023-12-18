using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class TagsModel
    {
        // Collection
        [Key]
        public int Id { get; set; }
        public string TagsName { get; set; }
        public string? TagsDescription { get; set; }
    }
}
