using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Entities
{
    [Table("SalesReceiptDetail")]
    public class SalesReceiptDetailEntity
    {
        [Key]
        public int Id { get; set; }
        public int SalesReceiptId { get; set; }
        public int SellQuantity { get; set; }
        public int ProductId { get; set; }

    }
}
