using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Avion
{
    public int IdAvion { get; set; }

    public string FabricanteAvion { get; set; } = null!;

    public string ModeloAvion { get; set; } = null!;

    public int CapacidadPasajerosAvion { get; set; }


}
