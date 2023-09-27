using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace DataObjectLayer
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductDesc { get; set; }

        public decimal? ProductPrice { get; set; }

        public decimal? ProductSalePrice { get; set; }

        public int? ProductStock { get; set; }

        public string? ProductImage { get; set; }

        public int? ProductCategory { get; set; }
    }
}
