using AppManager.Areas.Admin.Models;
using System.Collections.Generic;

namespace AppManager.Models
{
    public class CategoryMixItUpModel : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
