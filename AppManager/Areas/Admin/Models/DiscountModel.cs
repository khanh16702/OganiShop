using System;

namespace AppManager.Areas.Admin.Models
{
    public class DiscountModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OutOfDate { get; set; }
        public string CreatedBy { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
