using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Cart
{
    public Guid CartId { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
