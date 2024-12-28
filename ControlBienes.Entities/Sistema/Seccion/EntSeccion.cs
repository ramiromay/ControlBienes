using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Sistema.Seccion;

public partial class EntSeccion : EntRegistroGenerico
{
    public long iIdSeccion { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntSubModulo> SubModulos { get; set; } = new List<EntSubModulo>();
}
