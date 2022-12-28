namespace AppManager.Areas.Admin.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
