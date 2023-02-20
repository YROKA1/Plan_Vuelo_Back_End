using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Plan_aereo.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

}
