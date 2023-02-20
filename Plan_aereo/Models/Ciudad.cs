using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public int IdPais { get; set; }

}
