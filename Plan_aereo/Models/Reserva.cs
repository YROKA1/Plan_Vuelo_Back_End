using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public string CodigoReserva { get; set; } = null!;

    public int IdTarjeta { get; set; }

    public int IdVuelo { get; set; }

 
}
