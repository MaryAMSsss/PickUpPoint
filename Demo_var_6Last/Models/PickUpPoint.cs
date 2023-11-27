using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class PickUpPoint
{
    public int PointId { get; set; }

    public int? PostIndex { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public byte? House { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
