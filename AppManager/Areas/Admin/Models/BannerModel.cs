namespace AppManager.Areas.Admin.Models
{
    public class BannerModel : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public bool BigImage { get; set; }
        public int ToCategoryId { get; set; }
    }
}
