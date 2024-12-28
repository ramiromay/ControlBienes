using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.Empleado;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.Nombramiento;

public partial class EntNombramiento : EntRegistroGenerico
{
    public long iIdNombramiento { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntEmpleado> Empleados { get; set; } = new List<EntEmpleado>();
}
