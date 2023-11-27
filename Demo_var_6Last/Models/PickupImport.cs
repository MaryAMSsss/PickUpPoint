using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class PickupImport
{
    public int PostIndex { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public byte? House { get; set; }
}
