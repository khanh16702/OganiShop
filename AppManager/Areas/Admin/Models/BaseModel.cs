using System;

namespace AppManager.Areas.Admin.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
