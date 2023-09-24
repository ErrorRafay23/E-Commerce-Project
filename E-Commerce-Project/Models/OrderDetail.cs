using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? ProductId { get; set; }

    public int? ProductQty { get; set; }

    public decimal? ProductPrice { get; set; }

    public int? OrderId { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual OrderTable? Order { get; set; }

    public virtual Product? Product { get; set; }
}
