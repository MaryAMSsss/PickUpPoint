using System;
using System.Collections.Generic;

namespace Demo_var_6Last.Models;

public partial class ProductT
{
    public string Артикул { get; set; } = null!;

    public string Наименование { get; set; } = null!;

    public string ЕдиницаИзмерения { get; set; } = null!;

    public decimal Стоимость { get; set; }

    public int РазмерМаксимальноВозможнойСкидки { get; set; }

    public string Производитель { get; set; } = null!;

    public string Поставщик { get; set; } = null!;

    public string КатегорияТовара { get; set; } = null!;

    public int ДействующаяСкидка { get; set; }

    public int КолВоНаСкладе { get; set; }

    public string Описание { get; set; } = null!;

    public string? Изображение { get; set; }
}
