using System;
using System.Collections.Generic;

namespace ECommerceMVC.Data;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public bool? Sex { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? RandonKey { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
