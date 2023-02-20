using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Vuelo
{
    public int IdVuelo { get; set; }

    public int AeropuertoOrigen { get; set; }

    public int AeropuertoDestino { get; set; }

    public int FechaSalida { get; set; }

    public int FechaLlegada { get; set; }

    public int IdAerolinea { get; set; }

    public int IdTarifa { get; set; }

    public int IdAvion { get; set; }


   

}
