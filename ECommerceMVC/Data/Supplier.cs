using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Supplier
{
    public Guid SupplierId { get; set; }

    public string? SupplierName { get; set; }

    public string? Address { get; set; }

    public string? NumberPhone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
