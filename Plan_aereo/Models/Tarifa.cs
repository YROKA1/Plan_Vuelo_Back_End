using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Tarifa
{
    public int IdTarifa { get; set; }

    public double PrecioTarifa { get; set; }

    public int? ClaseAsiento { get; set; }

}
