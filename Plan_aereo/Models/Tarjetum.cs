using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Tarjetum
{
    public int IdTarjeta { get; set; }

    public long NumeroTarjeta { get; set; }

    public string FechaVencimiento { get; set; } = null!;

    public int IdPasajero { get; set; }

    public string TipoTarjeta { get; set; } = null!;

    public int IdBanco { get; set; }

}
