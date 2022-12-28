using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("CategoryImage")]
    public class CategoryImageEntity : BaseEntity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
        public int CategoryId { get; set; }
        public int FileId { get; set; }
        public bool IsAvatar { get; set; }
    }
}
