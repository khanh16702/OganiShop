using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("Banner")]
    public class BannerEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public bool BigImage { get; set; }
        public int ToCategoryId { get; set; }
    }
}
