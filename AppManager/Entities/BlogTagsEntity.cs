using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("BlogTags")]
    public class BlogTagsEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
