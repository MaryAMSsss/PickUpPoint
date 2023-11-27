using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class OrderProductImport
{
    public byte НомерЗаказа { get; set; }

    public string АртикулПродукта { get; set; } = null!;

    public byte Количество { get; set; }
}
