using System;
using System.Collections.Generic;

namespace AppManager.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SummaryContent { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string Unit { get; set; }
        public int CategoryId { get; set; }
        public List<string> Images { get; set; }
        public string ImagePath { get; set; }
    }
}
