using System;
using System.Collections.Generic;

namespace Marfia_HairTonic.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CutomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual Customer Cutomer { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
