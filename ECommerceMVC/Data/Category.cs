﻿using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Category
{
    public Guid CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
