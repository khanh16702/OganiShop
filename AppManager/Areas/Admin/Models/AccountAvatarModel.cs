using System;

namespace AppManager.Areas.Admin.Models
{
    public class AccountAvatarModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileFormat { get; set; }
        public int FileId { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
