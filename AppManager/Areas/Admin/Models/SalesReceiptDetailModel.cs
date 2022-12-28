namespace AppManager.Areas.Admin.Models
{
    public class SalesReceiptDetailModel
    {
        public int Id { get; set; }
        public int SalesReceiptId { get; set; }
        public int SellQuantity { get; set; }
        public int ProductId { get; set; }
    }
}
