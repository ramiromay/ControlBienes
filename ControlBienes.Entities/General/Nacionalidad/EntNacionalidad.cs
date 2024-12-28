using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.Persona;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.Nacionalidad;

public partial class EntNacionalidad : EntRegistroGenerico
{
    public long iIdNacionalidad { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntPersona> Personas { get; set; } = new List<EntPersona>();
}
