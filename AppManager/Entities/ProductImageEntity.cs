using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("ProductImage")]
    public class ProductImageEntity : BaseEntity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
        public int ProductId { get; set; }
        public int FileId { get; set; }
        public bool IsAvatar { get; set; }
    }
}
