using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Aeropuerto
{
    public int IdAeropuerto { get; set; }

    public string NombreAeropuerto { get; set; } = null!;

    public string NombreCiudad { get; set; } = null!;

	public string NombrePais { get; set; } = null!;

}
