using ControlBienes.Entities.Catalogos.Resguardante;
using ControlBienes.Entities.General.Nacionalidad;
using ControlBienes.Entities.Seguridad.Empleado;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.Persona;

public partial class EntPersona
{
    public long iIdPersona { get; set; }

    public string sNombres { get; set; }

    public string sPrimerNombre { get; set; }

    public string sSegundoNombre { get; set; }

    public bool bHombre { get; set; }

    public DateTime dtFechaNacimiento { get; set; }

    public long iIdNacionalidad { get; set; }

    public string sRfc { get; set; }

    public virtual ICollection<EntEmpleado> Empleados { get; set; } = new List<EntEmpleado>();

    public virtual EntNacionalidad Nacionalidad { get; set; }

    public virtual ICollection<EntResguardante> Resguardantes { get; set; } = new List<EntResguardante>();
}
