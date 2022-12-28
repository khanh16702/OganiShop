using AppManager.Areas.Admin.Models;

namespace AppManager.Models
{
    public class FileManageModel : BaseModel
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
    }
}
