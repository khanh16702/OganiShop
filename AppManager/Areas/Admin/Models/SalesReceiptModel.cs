using System;

namespace AppManager.Areas.Admin.Models
{
    public class SalesReceiptModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CustomerId { get; set; }
        public decimal Discount { get; set; }
    }
}
