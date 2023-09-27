using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Postal
{
    public int PostalCode { get; set; }

    public string PostalArea { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
