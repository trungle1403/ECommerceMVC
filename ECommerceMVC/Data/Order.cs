using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid? CustomerId { get; set; }

    public DateTime? DateOrder { get; set; }

    public DateTime? DateShip { get; set; }

    public string? Note { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
