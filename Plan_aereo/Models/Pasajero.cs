using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Pasajero
{
    public int IdPasajero { get; set; }

    public long NumIdentificacion { get; set; }

    public string UsuarioPasajero { get; set; } = null!;

    public string ClavePasajero { get; set; } = null!;

    public string NombrePasajero { get; set; } = null!;

    public string DireccionPasajero { get; set; } = null!;

    public int? CodigoPostalPasajero { get; set; }

    public long NumTelefonoPasajero { get; set; }

    public string CorreoPasajero { get; set; } = null!;

}
