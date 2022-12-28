using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("DiscountCode")]
    public class DiscountCodeEntity
    {
        [Key]
        public int  Id { get; set; }
        public decimal ReducedAmount { get; set; }
        public string UsedBy { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
