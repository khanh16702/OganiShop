using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("FileManage")]
    public class FileManageEntity : BaseEntity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
    }
}
