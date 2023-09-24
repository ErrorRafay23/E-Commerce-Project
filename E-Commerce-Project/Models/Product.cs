using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDesc { get; set; }

    public decimal? ProductPrice { get; set; }

    public decimal? ProductSalePrice { get; set; }

    public int? ProductStock { get; set; }

    public string? ProductImage { get; set; }

    public int? ProductCategory { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Category? ProductCategoryNavigation { get; set; }
}
