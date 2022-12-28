using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("Discount")]
    public class DiscountEntity
    {
        [Key]
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
