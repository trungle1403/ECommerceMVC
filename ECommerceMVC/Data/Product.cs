using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public string? Images { get; set; }

    public bool? IsUsing { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? SupplierId { get; set; }

    public Guid? StatusId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Status? Status { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
