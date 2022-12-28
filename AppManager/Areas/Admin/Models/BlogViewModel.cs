namespace AppManager.Areas.Admin.Models
{
    public class BlogViewModel : BaseModel
    {
        public string ImagePath { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int Comments { get; set; }
        public int BlogCategoryId { get; set; }
        public string AuthorImagePath { get; set; }
        public string BlogCategoryName { get; set; }
        public string TagsName { get; set; }
        public string CustomDate { get; set; }
        public string AuthorRole { get; set; }
    }
}
