using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("BlogCategory")]
    public class BlogCategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int NumberOfPost { get; set; }
    }
}
