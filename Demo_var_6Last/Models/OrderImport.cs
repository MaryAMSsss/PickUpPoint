using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class OrderImport
{
    public int НомерЗаказа { get; set; }

    public DateTime ДатаЗаказа { get; set; }

    public DateTime ДатаДоставки { get; set; }

    public byte ПунктВыдачи { get; set; }

    public string ФиоКлиента { get; set; } = null!;

    public short КодДляПолучения { get; set; }

    public string СтатусЗаказа { get; set; } = null!;
}
