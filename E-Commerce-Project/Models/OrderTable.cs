using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class OrderTable
{
    public int OrderId { get; set; }

    public int? OrderNumber { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? OrderTotal { get; set; }

    public DateTime? ShippingDate { get; set; }

    public string? IsDelivered { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
