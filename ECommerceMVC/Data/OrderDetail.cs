using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class OrderDetail
{
    public Guid OrderDetailId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
