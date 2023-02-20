using System;
using System.Collections.Generic;

namespace Plan_aereo.Models;

public partial class Asiento
{
    public int IdAsiento { get; set; }

    public int? ClaseAsiento { get; set; }

    public string FilaAsiento { get; set; } = null!;

    public string LetraAsiento { get; set; } = null!;

    public int? IdVuelo { get; set; }


	public int? DisponibilidadASiento { get; set; }
}
