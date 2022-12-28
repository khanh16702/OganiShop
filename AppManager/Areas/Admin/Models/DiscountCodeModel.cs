namespace AppManager.Areas.Admin.Models
{
    public class DiscountCodeModel
    {
        public int Id { get; set; }
        public decimal ReducedAmount { get; set; }
        public string UsedBy { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
