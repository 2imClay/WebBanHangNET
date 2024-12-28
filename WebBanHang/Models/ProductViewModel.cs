using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public List<SizeOption> Sizes { get; set; } = new List<SizeOption>();
        public string SelectedSizes { get; set; }
        public string Category { get; set; }
        public string Sex { get; set; }
    }

    public class SizeOption
    {
        public string Size { get; set; }
        public bool IsSelected { get; set; }
    }

}