using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("BannerImage")]
    public class BannerImageEntity : BaseEntity
    {
        public int BannerId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
        public int FileId { get; set; }
    }
}
