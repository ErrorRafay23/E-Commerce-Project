using System;
using System.Collections.Generic;

namespace E_Commerce_Project.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? CustomerEmail { get; set; }

    public string? CustomerPassword { get; set; }

    public string? CustomerAddress { get; set; }

    public int? CustomerCity { get; set; }

    public int? CustomerPostalCode { get; set; }

    public virtual City? CustomerCityNavigation { get; set; }

    public virtual Postal? CustomerPostalCodeNavigation { get; set; }

    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();
}
