using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Menu
{
    public Guid MenuId { get; set; }

    public string? MenuName { get; set; }

    public int? OrderNumber { get; set; }

    public Guid? MenuIdParent { get; set; }

    public bool? IsActive { get; set; }

    public string? Url { get; set; }

    public string? Icon { get; set; }
}
