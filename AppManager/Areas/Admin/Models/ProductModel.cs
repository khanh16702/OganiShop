using AppManager.Areas.Admin.Models;

namespace AppManager.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string Description { get; set; }
        public string SummaryContent { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string Unit { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public bool IsDiscount { get; set; }
    }
}
