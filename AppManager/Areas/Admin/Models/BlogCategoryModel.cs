namespace AppManager.Areas.Admin.Models
{
    public class BlogCategoryModel : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public int NumberOfPost { get; set; }
    }
}
