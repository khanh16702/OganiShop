﻿namespace AppManager.Areas.Admin.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

    }
}
