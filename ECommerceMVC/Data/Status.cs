using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Status
{
    public Guid StatusId { get; set; }

    public string? StatusName { get; set; }

    public string? Descripttion { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
