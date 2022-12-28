namespace AppManager.Areas.Admin.Models
{
    public class BannerImageModel : BaseModel
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
        public int BannerId { get; set; }
        public int FileId { get; set; }
    }
}
